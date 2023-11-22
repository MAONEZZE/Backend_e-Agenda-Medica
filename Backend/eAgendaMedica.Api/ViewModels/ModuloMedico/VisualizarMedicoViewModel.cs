namespace eAgendaMedica.Api.ViewModels.ModuloMedico
{
    public class VisualizarMedicoViewModel : VisualizarBase<VisualizarMedicoViewModel>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string HorasTotaisTrabalhadas { get; set; }
        public List<string> TitulosConsultas { get; set; }
        public List<string> TitulosCirurgias { get; set; }
    }
}
