namespace eAgendaMedica.Api.ViewModels.ModuloPaciente
{
    public class VisualizarPacienteViewModel : VisualizarBase<VisualizarPacienteViewModel>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public List<string> TituloConsulta { get; set; }
        public List<string> TituloCirurgia { get; set; }
    }
}
