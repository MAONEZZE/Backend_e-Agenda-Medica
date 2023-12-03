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

        public async Task<List<Consulta>> SelecionarConsultasFuturas(Guid usuarioId)
        {
            return await base.dbset.Where(x => x.Data > DateTime.Today).Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<List<Consulta>> SelecionarConsultasParaHoje(Guid usuarioId)
        {
            return await base.dbset.Where(x => x.Data == DateTime.Today).Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<List<Consulta>> SelecionarConsultasPassadas(Guid usuarioId)
        {
            return await base.dbset.Where(x => x.Data < DateTime.Today).Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }

        public override async Task<Consulta> SelecionarPorIdAsync(Guid id)
        {
            return await base.dbset.Where(x => x.Id == id).Include(x => x.Medico).Include(x => x.PacienteAtributo).FirstOrDefaultAsync();
        }
    }
}
