using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Infra.Compartilhado;

namespace eAgendaMedica.Infra.ModuloConsulta
{
    public class RepositorioConsulta : RepositorioBase<Consulta>, IRepositorioConsulta
    {
        public RepositorioConsulta(IContextoPersistencia ctx) : base(ctx)
        {
        }

        public Task<List<Consulta>> SelecionarConsultasFuturas()
        {
            return base.dbset.Where(x => x.Data > DateTime.Now).ToListAsync();
        }

        public Task<List<Consulta>> SelecionarConsultasPassadas()
        {
            return base.dbset.Where(x => x.Data < DateTime.Now).ToListAsync();
        }
    }
}
