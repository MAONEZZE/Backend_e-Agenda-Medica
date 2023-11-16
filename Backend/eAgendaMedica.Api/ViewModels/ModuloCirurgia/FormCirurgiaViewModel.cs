namespace eAgendaMedica.Api.ViewModels.ModuloCirurgia
{
    public class FormCirurgiaViewModel : FormBase<FormCirurgiaViewModel>
    {
        public string Titulo { get; set; }
        public Guid Paciente_id { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public List<Guid> Id_Medicos { get; set; }
    }
}
