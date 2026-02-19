using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiAutenticacao.Models.DTO
{
	public class CadastroEnderecoDTO
	{

		[Required(ErrorMessage = "O campo logradour é obrigatório")]
		[StringLength(200, ErrorMessage = "O campo logradouro deve ter no máximo 200 caracteres")]
		public string Logradouro { get; set; } = string.Empty;

		[Required(ErrorMessage = "O campo número é obrigatório")]
		public string Numero { get; set; } = string.Empty;

		[StringLength(200, ErrorMessage = "O campo logradouro deve ter no máximo 200 caracteres")]
		public string Complemento { get; set; } = string.Empty;

		[Required(ErrorMessage = "O campo bairro é obrigatório")]
		[StringLength(100, ErrorMessage = "O campo bairro deve ter no máximo 100 caracteres")]
		public string Bairro { get; set; } = string.Empty;

		[Required(ErrorMessage = "O campo cidade é obrigatório")]
		[StringLength(100, ErrorMessage = "O campo cidade deve ter no máximo 100 caracteres")]
		public string Cidade { get; set; } = string.Empty;


		[Required(ErrorMessage = "O campo estado é obrigatório")]
		[StringLength(50, ErrorMessage = "O campo estado deve ter no máximo 50 caracteres")]
		public string Estado { get; set; } = string.Empty;

		[Required(ErrorMessage = "O campo cep é obrigatório")]
		[StringLength(20, ErrorMessage = "O campo cep deve ter no máximo 20 caracteres")]
		public string Cep { get; set; } = string.Empty;

		[ForeignKey(nameof(Usuario))]
		public int UsuarioId { get; set; }

	}
}
