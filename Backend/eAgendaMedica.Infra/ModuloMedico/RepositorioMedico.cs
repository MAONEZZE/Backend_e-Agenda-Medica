using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.Infra.ModuloMedico
{
    public class RepositorioMedico : RepositorioBase<Medico>, IRepositorioMedico
    {
        public RepositorioMedico(IContextoPersistencia ctx) : base(ctx)
        {
        }

        public override async Task<List<Medico>> SelecionarTodosAsync()
        {
            return await base.dbset.Include(x => x.Consultas).Include(x => x.Cirurgias).ToListAsync();
        }

        public async Task<List<Medico>> SelecionarMedicosQueMaisTrabalharam(DateTime dataInicio, DateTime dataFinal)
        {
            var listaMedciosRank = new List<Medico>();
            var listaMedicos = await SelecionarTodosAsync();

            foreach(var medico in listaMedicos)
            {
                medico.HorasTrabalhadasPeriodoTempo(dataInicio, dataFinal);

                if (medico.HorasTotaisTrabalhadasPriodoTempo != TimeSpan.Zero)
                {
                    listaMedciosRank.Add(medico);
                }
            }

            return listaMedciosRank.OrderByDescending(x => x.HorasTotaisTrabalhadasPriodoTempo).Take(10).ToList();
        }

        public override async Task<Medico> SelecionarPorIdAsync(Guid id)
        {
            return await base.dbset.Where(x => x.Id == id).Include(x => x.Consultas).Include(x => x.Cirurgias).FirstOrDefaultAsync();
        }

        public async Task<Medico> SelecionarPorCRM(string crm)
        {
            return await base.dbset.Where(x => x.Crm == crm).Include(x => x.Consultas).Include(x => x.Cirurgias).FirstOrDefaultAsync();
        }

        public async Task<List<Medico>> SelecionarMuitosAsync(List<Guid> idMedicosSelecionados)
        {
            return await base.dbset.Where(medico => idMedicosSelecionados.Contains(medico.Id)).Include(x => x.Consultas).Include(x => x.Cirurgias).ToListAsync();
        }
    }
}
