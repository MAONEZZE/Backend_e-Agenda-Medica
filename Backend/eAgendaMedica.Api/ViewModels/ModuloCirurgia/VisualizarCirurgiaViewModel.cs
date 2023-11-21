using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Api.ViewModels.ModuloPaciente;

namespace eAgendaMedica.Api.ViewModels.ModuloCirurgia
{
    public class VisualizarCirurgiaViewModel : VisualizarBase<VisualizarCirurgiaViewModel>
    {
        public string Titulo { get; set; }
        public ListarPacienteViewModel PacienteAtributo { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public List<ListarMedicoViewModel> Medicos { get; set; }
    }
}
