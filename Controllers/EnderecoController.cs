using apiAutenticacao.Models;
using apiAutenticacao.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiAutenticacao.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EnderecoController : ControllerBase
	{

		private readonly EnderecoService _enderecoService;
		private readonly UsuarioService _usuarioService;

		public EnderecoController(EnderecoService enderecoService, UsuarioService usuarioService)
		{

			_enderecoService = enderecoService;
			_usuarioService = usuarioService;
		}


		[HttpGet("GetAllEnderecos")]
		public async Task<IActionResult> GetAllAsync() {

			List<Endereco> listEnderecos = await _enderecoService.GetEnderecosAsync();

			return Ok(listEnderecos);

		}

		[HttpPost("CreateAdress")]
		public async Task<IActionResult> CreateAdressAsync([FromBody] Endereco endereco) {

			if (!ModelState.IsValid)
			{
				return BadRequest("Dados inválidos");
			}

			//Usuario? usuario = await _usuarioService.GetUserById(endereco.UsuarioId);

			//if (usuario == null) { 
			
			//	return BadRequest("Usuário não encontrado");

			//}


			bool result = await _enderecoService.CreateAddressAsync(endereco);

			if (result) {

				return Ok("Endereço criado com sucesso");
			
			}

			return BadRequest("Erro ao criar o endereço");



		}

	}
}
