namespace eAgendaMedica.Api.ViewModels.ModuloConsulta
{
    public class VisualizarConsultaViewModel : VisualizarBase<VisualizarConsultaViewModel>
    {
        public string Titulo { get; set; }
        public string Paciente { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public string Medico { get; set; }
    }
}
