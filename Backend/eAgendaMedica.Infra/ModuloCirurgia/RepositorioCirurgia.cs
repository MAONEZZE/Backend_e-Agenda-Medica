using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Infra.Compartilhado;

namespace eAgendaMedica.Infra.ModuloCirurgia
{
    public class RepositorioCirurgia : RepositorioBase<Cirurgia>, IRepositorioCirurgia
    {
        public RepositorioCirurgia(IContextoPersistencia ctx) : base(ctx)
        {
        }

        public async Task<List<Cirurgia>> SelecionarCirurgiasFuturasComDataAlvo(DateTime dataAlvo)
        {
            return await base.dbset.Where(x => x.Data > dataAlvo).ToListAsync();
        }

        public async Task<List<Cirurgia>> SelecionarCirurgiasParaHoje()
        {
            return await base.dbset.Where(x => x.Data == DateTime.Now).ToListAsync();
        }

        public async Task<List<Cirurgia>> SelecionarCirurgiasPassadasComDataAlvo(DateTime dataAlvo)
        {
            return await base.dbset.Where(x => x.Data < dataAlvo).ToListAsync();
        }
    }
}
