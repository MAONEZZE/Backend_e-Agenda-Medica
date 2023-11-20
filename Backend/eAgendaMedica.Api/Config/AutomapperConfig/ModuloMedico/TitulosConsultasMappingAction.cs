using AutoMapper;
using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloMedico
{
    public class TitulosConsultasMappingAction : IMappingAction<Medico, VisualizarMedicoViewModel>
    {
        public void Process(Medico medico, VisualizarMedicoViewModel medicoVM, ResolutionContext ctx)
        {
            medicoVM.TituloConsultas.AddRange(medico.TitulosConsultas);
        }
    }
}