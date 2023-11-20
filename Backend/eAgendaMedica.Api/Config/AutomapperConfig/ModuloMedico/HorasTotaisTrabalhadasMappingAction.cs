using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloMedico
{
    public class HorasTotaisTrabalhadasMappingAction : IMappingAction<Medico, VisualizarMedicoViewModel>
    {
        public void Process(Medico medico, VisualizarMedicoViewModel medicoVM, ResolutionContext ctx)
        {
            medicoVM.HorasTotaisTrabalhadas = Convert.ToDouble(medico.HorasTotaisTrabalhadas);
        }
    }
}