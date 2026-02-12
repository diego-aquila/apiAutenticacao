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

		public EnderecoController(EnderecoService enderecoService) {

			_enderecoService = enderecoService;
		}


		[HttpGet("GetAllEnderecos")]
		public async Task<IActionResult> GetAllAsync() {

			List<Endereco> listEnderecos = await _enderecoService.GetEnderecosAsync();

			return Ok(listEnderecos);

		}

	}
}
