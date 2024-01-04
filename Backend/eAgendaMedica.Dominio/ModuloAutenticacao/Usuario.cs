using Microsoft.AspNetCore.Identity;
using Taikandi;

namespace eAgendaMedica.Dominio.ModuloAutenticacao
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Nome { get; set; }
        public Usuario()
        {
            Id = SequentialGuid.NewGuid();
        }
    }
}
