using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Api.ViewModels.ModuloPaciente;

namespace eAgendaMedica.Api.ViewModels.ModuloConsulta
{
    public class VisualizarConsultaViewModel : VisualizarBase<VisualizarConsultaViewModel>
    {
        public string Titulo { get; set; }
        public ListarPacienteViewModel Paciente_id { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public ListarMedicoViewModel Medico { get; set; }
    }
}
