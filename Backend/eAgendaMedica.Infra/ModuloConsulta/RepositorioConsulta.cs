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

        public async Task<List<Consulta>> SelecionarConsultasFuturasComDataAlvo()
        {
            return await base.dbset.Where(x => x.Data > DateTime.Today).ToListAsync();
        }

        public async Task<List<Consulta>> SelecionarConsultasParaHoje()
        {
            return await base.dbset.Where(x => x.Data == DateTime.Today).ToListAsync();
        }

        public async Task<List<Consulta>> SelecionarConsultasPassadasComDataAlvo()
        {
            return await base.dbset.Where(x => x.Data < DateTime.Today).ToListAsync();
        }

        public override async Task<Consulta> SelecionarPorIdAsync(Guid id)
        {
            return await base.dbset.Where(x => x.Id == id).Include(x => x.Medico).Include(x => x.PacienteAtributo).FirstOrDefaultAsync();
        }
    }
}
