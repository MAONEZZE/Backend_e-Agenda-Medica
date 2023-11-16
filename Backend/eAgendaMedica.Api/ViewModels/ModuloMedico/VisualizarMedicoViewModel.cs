namespace eAgendaMedica.Api.ViewModels.ModuloMedico
{
    public class VisualizarMedicoViewModel : VisualizarBase<VisualizarMedicoViewModel>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public List<string> TituloConsulta { get; set; }
        public List<string> TituloCirurgia { get; set; }
    }
}
