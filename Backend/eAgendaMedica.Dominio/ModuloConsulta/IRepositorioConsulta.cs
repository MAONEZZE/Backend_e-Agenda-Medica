using eAgendaMedica.Dominio.ModuloCirurgia;

namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public interface IRepositorioConsulta : IRepositorioBase<Consulta>
    {
        public Task<List<Consulta>> SelecionarConsultasPassadas(Guid usuarioId);
        public Task<List<Consulta>> SelecionarConsultasFuturas(Guid usuarioId);
        public Task<List<Consulta>> SelecionarConsultasParaHoje(Guid usuarioId);
    }
}
