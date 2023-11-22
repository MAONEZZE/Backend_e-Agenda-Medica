namespace eAgendaMedica.Api.ViewModels.ModuloPaciente
{
    public class ListarPacienteViewModel : ListarBase<ListarPacienteViewModel>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int QtdConsultas { get; set; }
        public int QtdCirurgias { get; set; }
    }
}
