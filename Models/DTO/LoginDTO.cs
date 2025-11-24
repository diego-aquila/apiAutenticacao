using System.ComponentModel.DataAnnotations;

namespace apiAutenticacao.Models.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Email é obrigatório")]
        [EmailAddress(ErrorMessage ="Formato de email inválido")]
        public string Email { get; set; } = string.Empty;
		[Required(ErrorMessage = "Senha é obrigatória")]
		public string Senha { get; set; } = string.Empty;
	}
}
