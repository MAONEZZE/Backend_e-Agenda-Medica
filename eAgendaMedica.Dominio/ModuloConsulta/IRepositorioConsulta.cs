namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public interface IRepositorioConsulta : IRepositorioBase<Consulta>
    {
        public Task<List<Consulta>> SelecionarConsultasPassadas();
        public Task<List<Consulta>> SelecionarConsultasFuturas();
    }
}
