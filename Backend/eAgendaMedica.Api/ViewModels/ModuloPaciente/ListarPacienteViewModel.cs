namespace eAgendaMedica.Api.ViewModels.ModuloPaciente
{
    public class ListarPacienteViewModel : ListarBase<ListarPacienteViewModel>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public int QtdConsultas { get; set; }
        public int QtdCirurgias { get; set; }
    }
}
