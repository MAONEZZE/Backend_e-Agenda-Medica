namespace eAgendaMedica.Api.ViewModels.ModuloConsulta
{
    public class ListarConsultaViewModel : ListarBase<ListarConsultaViewModel>
    {
        public string Titulo { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }

    }
}
