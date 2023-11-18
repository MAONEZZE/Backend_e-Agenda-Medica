namespace eAgendaMedica.Api.ViewModels.ModuloMedico
{
    public class VisualizarMedicoViewModel : VisualizarBase<VisualizarMedicoViewModel>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public double HorasTotaisTrabalhadas { get; set; }
        public List<string> TituloConsultas { get; set; }
        public List<string> TituloCirurgias { get; set; }
    }
}
