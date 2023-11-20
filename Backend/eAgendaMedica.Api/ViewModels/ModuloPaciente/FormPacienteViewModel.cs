namespace eAgendaMedica.Api.ViewModels.ModuloPaciente
{
    public class FormPacienteViewModel : FormBase<FormPacienteViewModel>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
