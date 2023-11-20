namespace eAgendaMedica.Api.ViewModels.ModuloMedico
{
    public class ListarMedicoViewModel : ListarBase<ListarMedicoViewModel>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public int QtdConsultas { get; set; }
        public int QtdCirurgias { get; set; }
    }
}
