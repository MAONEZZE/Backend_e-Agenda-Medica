namespace eAgendaMedica.Api.ViewModels.ModuloCirurgia
{
    public class VisualizarCirurgiaViewModel : VisualizarBase<VisualizarCirurgiaViewModel>
    {
        public string Titulo { get; set; }
        public string Paciente { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public List<string> Medicos { get; set; }
    }
}
