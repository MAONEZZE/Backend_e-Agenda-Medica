using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Infra.Compartilhado;

namespace eAgendaMedica.Infra.ModuloMedico
{
    public class RepositorioMedico : RepositorioBase<Medico>, IRepositorioMedico
    {
        public RepositorioMedico(IContextoPersistencia ctx) : base(ctx)
        {
        }
    }
}
