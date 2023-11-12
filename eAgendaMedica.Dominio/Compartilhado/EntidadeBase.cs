using Taikandi;

namespace eAgendaMedica.Dominio.Compartilhado
{
    public class EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            this.Id = SequentialGuid.NewGuid();
        }
    }
}
