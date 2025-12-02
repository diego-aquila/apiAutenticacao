using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
using apiAutenticacao.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;


namespace apiAutenticacao.Services
{
    public class AuthService
    {

        private readonly AppDbContext _context;


        public AuthService(AppDbContext context) {

            _context = context;
        
        }


        public async Task<ResponseLogin> Login(LoginDTO dadosUsuario)
        {

            Usuario? usuarioEncontrado = await _context.Usuarios.
                FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuario.Email);

            if (usuarioEncontrado != null)
            {
                bool isValidPassword = Verify(dadosUsuario.Senha, usuarioEncontrado.Senha);

                if (isValidPassword)
                {
                    return new ResponseLogin { 
                    
                        Erro = false,
                        Message = "Login Realizado com sucesso",
                        Usuario = new Usuario { 
                        
                            Nome = usuarioEncontrado.Nome,
                            Email = usuarioEncontrado.Email
                        
                        }

                    };

                }

                return new ResponseLogin { 
                
                    Erro = true,
                    Message = "Login não realizado. Email ou senha incorretos",
                    
                };

            }

            return new ResponseLogin { 
            
                Erro = true,
                Message = "Usuário não encontrado",
                
            };


        }

        public async Task<ResponseCadastro> CadastrarUsuarioAsync(CadastroUsuarioDTO dadosUsuarioCadastro) {

            Usuario? usuarioExistente = await _context.Usuarios.
               FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuarioCadastro.Email);

            if (usuarioExistente != null)
            {


                return new ResponseCadastro { 
                
                    Erro = true,
                    Message = "Este email já está cadastrado no sistema"
                
                };

                
            }

            Usuario usuario = new()
            {

                Nome = dadosUsuarioCadastro.Nome,
                Email = dadosUsuarioCadastro.Email,
                Senha = HashPassword(dadosUsuarioCadastro.Senha),
                ConfirmarSenha = HashPassword(dadosUsuarioCadastro.ConfirmarSenha)


            };

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return new ResponseCadastro { 
            
                Erro = false,
                Message = "Usuário cadastrado com sucesso",
                Usuario = usuario
                

            } ;



        }






    }
}
