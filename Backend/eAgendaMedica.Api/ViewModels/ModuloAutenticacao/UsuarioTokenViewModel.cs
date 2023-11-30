using eAgendaMedica.Dominio.ModuloAutenticacao;

namespace eAgendaMedica.Api.ViewModels.ModuloAutenticacao
{
    public class UsuarioTokenViewModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public UsuarioTokenViewModel(Guid id, string login, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Login = login;
        }

    }
}
