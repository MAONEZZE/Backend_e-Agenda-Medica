using System.ComponentModel.DataAnnotations.Schema;
using Taikandi;

namespace eAgendaMedica.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }

        public EntidadeBase()
        {
            this.Id = SequentialGuid.NewGuid();
        }

    }
}
