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

        public Task<List<Cirurgia>> SelecionarCirurgiasFuturas()
        {
            return base.dbset.Where(x => x.Data > DateTime.Now).ToListAsync();
        }

        public Task<List<Cirurgia>> SelecionarCirurgiasPassadas()
        {
            return base.dbset.Where(x => x.Data < DateTime.Now).ToListAsync();
        }
    }
}
