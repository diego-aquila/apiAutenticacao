using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
using apiAutenticacao.Models.Responses;
using apiAutenticacao.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace apiAutenticacao.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UsuariosController(IAuthService authService) {

			_authService = authService;

        }

       [HttpPost("cadastrar")]
       public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] CadastroUsuarioDTO dadosUsuario) {

            if (!ModelState.IsValid) { 

                return BadRequest(ModelState);
            }

            ResponseCadastro response = await _authService.CadastrarUsuarioAsync(dadosUsuario);
            if (response.Erro)
            {
                return BadRequest(response);
            }
            
                return Ok(response);

			


        }

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync([FromBody] LoginDTO dadosLogin)
		{

			if (!ModelState.IsValid)
			{

				return BadRequest(ModelState);
			}

			ResponseCadastro response = await _authService.LoginAsync(dadosLogin);
			if (response.Erro)
			{
				return BadRequest(response);
			}

			return Ok(response);




		}



	}


}

