namespace eAgendaMedica.Api.ViewModels.ModuloConsulta
{
    public class ListarConsultaViewModel : ListarBase<ListarConsultaViewModel>
    {
        public string Titulo { get; set; }
        public Guid Paciente_id { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public Guid Id_Medico { get; set; }
    }
}
