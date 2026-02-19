using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace apiAutenticacao.Services
{
	public class EnderecoService
	{
		private readonly AppDbContext _context;

		public EnderecoService(AppDbContext context) { 
		
			_context = context;

		}


		public async Task<List<Endereco>> GetEnderecosAsync() {

			return await _context.Endereco.ToListAsync();
		
		}

		public async Task<bool> CreateAddressAsync(CadastroEnderecoDTO endereco) {


			Endereco enderecoGravar = new Endereco
			{
				Logradouro = endereco.Logradouro,
				Numero = endereco.Numero,
				Complemento = endereco.Complemento,
				Bairro = endereco.Bairro,
				Cidade = endereco.Cidade,
				Estado = endereco.Estado,
				Cep = endereco.Cep,
				UsuarioId = endereco.UsuarioId
			};
			

			_context.Endereco.Add(enderecoGravar);
			int result = await _context.SaveChangesAsync();

			return result > 0;

		}



	}
}
