using apiAutenticacao.Data;
using apiAutenticacao.Models;
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

		public async Task<bool> CreateAddressAsync(Endereco endereco) {

			_context.Endereco.Add(endereco);
			int result = await _context.SaveChangesAsync();

			return result > 0;

		}



	}
}
