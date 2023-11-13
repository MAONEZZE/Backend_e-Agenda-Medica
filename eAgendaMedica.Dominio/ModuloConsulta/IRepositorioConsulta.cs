namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public interface IRepositorioConsulta : IRepositorioAtividade<Consulta>
    {
        public Task<List<Consulta>> SelecionarConsultasPassadas();
        public Task<List<Consulta>> SelecionarConsultasFuturas();
    }
}
