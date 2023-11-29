namespace eAgendaMedica.Api.ViewModels.ModuloAutenticacao
{
    public class TokenViewModel
    {
        public string Chave { get; set; }
        public DateTime DataExpiração { get; set; }
        public UsuarioTokenViewModel Usuario { get; set; }
        
    }
}
