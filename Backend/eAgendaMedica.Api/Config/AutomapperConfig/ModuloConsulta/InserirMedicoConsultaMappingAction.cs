using eAgendaMedica.Api.ViewModels.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloConsulta
{
    public class InserirMedicoConsultaMappingAction : IMappingAction<FormConsultaViewModel, Consulta>
    {
        private readonly IRepositorioMedico repMedico;

        public InserirMedicoConsultaMappingAction(IRepositorioMedico repMedico)
        {
            this.repMedico = repMedico;
        }

        public void Process(FormConsultaViewModel consultaVM, Consulta consulta, ResolutionContext ctx)
        {
            var medico = repMedico.SelecionarPorIdAsync(consultaVM.Id_Medico).Result;

            consulta.AdicionarMedico(medico);
        }
    }
}