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

        public Task<List<Medico>> SelecionarMedicosQueMaisTrabalharam()
        {
            throw new NotImplementedException();
        }

        public Task<Medico> SelecionarPorCRM(string crm)
        {
            return base.dbset.SingleOrDefaultAsync(x => x.Crm == crm);
        }

        public Task<Medico> VerificarDisponibilidade()
        {
            throw new NotImplementedException();
        }
    }
}
