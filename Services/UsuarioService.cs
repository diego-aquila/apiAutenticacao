using apiAutenticacao.Data;
using apiAutenticacao.Models;
using Microsoft.EntityFrameworkCore;

namespace apiAutenticacao.Services
{
	public class UsuarioService(AppDbContext context)
	{
		private readonly AppDbContext _context = context;

		public async Task<List<Usuario>> GetAllUsers()
		{
			List<Usuario> listUsers = await _context.Usuarios.
				Include(usuario => usuario.Enderecos)
				.ToListAsync();

			return listUsers;

		}

		public async Task<Usuario?> GetUserById(int id) {

			Usuario? usuarioEncontrado = 
				await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);

			return usuarioEncontrado;

		}



	}
}
