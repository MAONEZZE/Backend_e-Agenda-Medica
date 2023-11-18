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

        public async Task<List<Medico>> SelecionarMedicosQueMaisTrabalharam(DateTime dataInicio, DateTime dataFinal)
        {
            var listaMedicos = await base.SelecionarTodosAsync();

            foreach(var medico in listaMedicos)
            {
                medico.HorasTrabalhadasPeriodoTempo(dataInicio, dataFinal);
            }

            return listaMedicos.OrderByDescending(x => x.HorasTotaisTrabalhadas).ToList();
        }

        public async Task<Medico> SelecionarPorCRM(string crm)
        {
            return await base.dbset.SingleOrDefaultAsync(x => x.Crm == crm);
        }

        public async Task<List<Medico>> SelecionarMuitosAsync(List<Guid> idMedicosSelecionados)
        {
            return await base.dbset.Where(medico => idMedicosSelecionados.Contains(medico.Id)).ToListAsync();
        }
    }
}
