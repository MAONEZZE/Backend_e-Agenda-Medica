using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Infra.Compartilhado;

namespace eAgendaMedica.Infra.ModuloConsulta
{
    public class RepositorioConsulta : RepositorioBase<Consulta>, IRepositorioConsulta
    {
        public RepositorioConsulta(IContextoPersistencia ctx) : base(ctx)
        {
        }

        public async Task<List<Consulta>> SelecionarConsultasFuturasComDataAlvo(DateTime dataAlvo)
        {
            return await base.dbset.Where(x => x.Data > dataAlvo).ToListAsync();
        }

        public async Task<List<Consulta>> SelecionarConsultasPassadasComDataAlvo(DateTime dataAlvo)
        {
            return await base.dbset.Where(x => x.Data < dataAlvo).ToListAsync();
        }
    }
}
