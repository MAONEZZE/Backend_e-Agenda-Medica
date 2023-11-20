namespace eAgendaMedica.Api.ViewModels.ModuloCirurgia
{
    public class FormCirurgiaViewModel : FormBase<FormCirurgiaViewModel>
    {
        public string Titulo { get; set; }
        public Guid Paciente_id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public List<Guid> Id_Medicos { get; set; }
    }
}
