using apiAutenticacao.Models.DTO;
using apiAutenticacao.Models.Responses;

namespace apiAutenticacao.Services
{
	public interface IAuthService
	{
		Task<ResponseCadastro> CadastrarUsuarioAsync(CadastroUsuarioDTO dadosUsuario);
		Task<ResponseCadastro> LoginAsync(LoginDTO dadosLogin);

	}
}
