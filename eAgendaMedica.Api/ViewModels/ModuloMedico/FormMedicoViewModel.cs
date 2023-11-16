namespace eAgendaMedica.Api.ViewModels.ModuloMedico
{
    public class FormMedicoViewModel : FormBase<FormMedicoViewModel>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
    }
}
