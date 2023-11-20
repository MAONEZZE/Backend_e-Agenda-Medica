namespace eAgendaMedica.Api.ViewModels.ModuloCirurgia
{
    public class ListarCirurgiaViewModel : ListarBase<ListarCirurgiaViewModel>
    {
        public string Titulo { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
    }
}
