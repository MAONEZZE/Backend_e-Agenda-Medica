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

        public async Task<List<Medico>> SelecionarMedicosQueMaisTrabalharam()
        {
            throw new NotImplementedException();
        }

        public async Task<Medico> SelecionarPorCRM(string crm)
        {
            return await base.dbset.SingleOrDefaultAsync(x => x.Crm == crm);
        }

        public async Task<Medico> VerificarDisponibilidade()
        {
            throw new NotImplementedException();
        }
    }
}
