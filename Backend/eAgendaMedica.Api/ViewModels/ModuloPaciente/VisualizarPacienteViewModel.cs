namespace eAgendaMedica.Api.ViewModels.ModuloPaciente
{
    public class VisualizarPacienteViewModel : VisualizarBase<VisualizarPacienteViewModel>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public List<string> TitulosConsultas { get; set; }
        public List<string> TitulosCirurgias { get; set; }
    }
}
