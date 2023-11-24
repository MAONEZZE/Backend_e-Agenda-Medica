using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Infra.Compartilhado;

namespace eAgendaMedica.Infra.ModuloCirurgia
{
    public class RepositorioCirurgia : RepositorioBase<Cirurgia>, IRepositorioCirurgia
    {
        public RepositorioCirurgia(IContextoPersistencia ctx) : base(ctx)
        {
        }

        public async Task<List<Cirurgia>> SelecionarCirurgiasFuturasComDataAlvo()
        {
            return await base.dbset.Where(x => x.Data > DateTime.Today).ToListAsync();
        }

        public async Task<List<Cirurgia>> SelecionarCirurgiasParaHoje()
        {
            return await base.dbset.Where(x => x.Data == DateTime.Today).ToListAsync();
        }

        public async Task<List<Cirurgia>> SelecionarCirurgiasPassadasComDataAlvo()
        {
            return await base.dbset.Where(x => x.Data < DateTime.Today).ToListAsync();
        }

        public override async Task<Cirurgia> SelecionarPorIdAsync(Guid id)
        {
            return await base.dbset.Where(x => x.Id == id).Include(x => x.Medicos).Include(x => x.PacienteAtributo).FirstOrDefaultAsync();
        }
    }
}
