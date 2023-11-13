using System.ComponentModel.DataAnnotations.Schema;
using Taikandi;

namespace eAgendaMedica.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        [NotMapped]
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            this.Id = SequentialGuid.NewGuid();
        }
    }
}
