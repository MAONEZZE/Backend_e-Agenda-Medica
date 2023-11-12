using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloPaciente;
using eAgendaMedica.Infra.Compartilhado;

namespace eAgendaMedica.Infra.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioBase<Paciente>, IRepositorioPaciente
    {
        public RepositorioPaciente(IContextoPersistencia ctx) : base(ctx)
        {
        }
    }
}
