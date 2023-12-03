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

        public override async Task<Paciente> SelecionarPorIdAsync(Guid id)
        {
            return await base.dbset.Where(x => x.Id == id).Include(x => x.Cirurgias).Include(x => x.Consultas).FirstOrDefaultAsync();
        }

        public override async Task<List<Paciente>> SelecionarTodosAsync(Guid usuarioId)
        {
            return await base.dbset.Include(x => x.Cirurgias).Include(x => x.Consultas).Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }
    }
}
