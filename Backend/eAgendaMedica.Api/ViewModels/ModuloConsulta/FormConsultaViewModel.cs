namespace eAgendaMedica.Api.ViewModels.ModuloConsulta
{
    public class FormConsultaViewModel : FormBase<FormConsultaViewModel>
    {
        public string Titulo { get; set; }
        public Guid Paciente_id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public Guid Id_Medico { get; set; }
    }
}
