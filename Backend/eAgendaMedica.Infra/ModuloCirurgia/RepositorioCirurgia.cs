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

        public async Task<List<Cirurgia>> SelecionarCirurgiasFuturas(Guid usuarioId)
        {
            return await base.dbset.Where(x => x.Data > DateTime.Today).Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<List<Cirurgia>> SelecionarCirurgiasParaHoje(Guid usuarioId)
        {
            return await base.dbset.Where(x => x.Data == DateTime.Today).Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<List<Cirurgia>> SelecionarCirurgiasPassadas(Guid usuarioId)
        {
            return await base.dbset.Where(x => x.Data < DateTime.Today).Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }

        public override async Task<Cirurgia> SelecionarPorIdAsync(Guid id)
        {
            return await base.dbset.Where(x => x.Id == id).Include(x => x.Medicos).Include(x => x.PacienteAtributo).FirstOrDefaultAsync();
        }
    }
}
