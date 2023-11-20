using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloMedico
{
    public class TitulosCirurgiasMappingAction : IMappingAction<Medico, VisualizarMedicoViewModel>
    {
        public void Process(Medico medico, VisualizarMedicoViewModel medicoVM, ResolutionContext ctx)
        {
            medicoVM.TituloCirurgias.AddRange(medico.TitulosCirurgias);
        }
    }
}