using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
using apiAutenticacao.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using static BCrypt.Net.BCrypt;


namespace apiAutenticacao.Services
{
    public class AuthService : IAuthService
	{
        private readonly AppDbContext _dbContext;

        public AuthService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
		}

        public async Task<ResponseCadastro> CadastrarUsuarioAsync(CadastroUsuarioDTO dadosUsuario)
        {

            var usuarioExistente = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == dadosUsuario.Email).ConfigureAwait(false);

            if (usuarioExistente != null)
            {
                return new ResponseCadastro
				{ 
                    
                    Erro = true,
                    Message = "Usuário já existe no banco de dados"
                
                }; 
			}

            var novoUsuario = new Usuario
            {
                Nome = dadosUsuario.Nome,
                Email = dadosUsuario.Email,
                Senha = HashPassword(dadosUsuario.Senha),
                ConfirmarSenha = HashPassword(dadosUsuario.ConfirmarSenha),

            };

            await _dbContext.Usuarios.AddAsync(novoUsuario).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync();

			return new ResponseCadastro
			{ 
                
                Erro = false,
                Message = "Usuário cadastrado com sucesso",
                Usuario = new UsuarioCadastrado { 
                    Id = novoUsuario.Id,
                    Nome = novoUsuario.Nome,
                    Email = novoUsuario.Email

				}


			}; 

		}

        public async Task<ResponseCadastro> LoginAsync(LoginDTO dadosLogin)
        {
            Usuario? user = await _dbContext.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosLogin.Email);

            if (user != null)
            {

				bool isValidPass = Verify(dadosLogin.Senha, user.Senha);


				if (isValidPass)
				{
					return new ResponseCadastro
					{
						Erro = false,
						Message = "Login realizado com sucesso",
						Usuario = new UsuarioCadastrado
						{
							Id = user.Id,
							Nome = user.Nome,
							Email = user.Email
						}
					};
				}


			}

           

			return new ResponseCadastro
			{
				Erro = true,
				Message = $"Email ou senha inválidos",
				
			};



		}
    }
}
