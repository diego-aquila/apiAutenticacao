namespace apiAutenticacao.Models.Responses
{
	public class ResponseCadastro
	{
		public bool Erro { get; set; }
		public string Message { get; set; } = string.Empty;
		public UsuarioCadastrado? Usuario { get; set; }
	}
}
