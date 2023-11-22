using eAgendaMedica.Dominio.ModuloCirurgia;

namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public interface IRepositorioConsulta : IRepositorioBase<Consulta>
    {
        public Task<List<Consulta>> SelecionarConsultasPassadasComDataAlvo();
        public Task<List<Consulta>> SelecionarConsultasFuturasComDataAlvo();
        public Task<List<Consulta>> SelecionarConsultasParaHoje();
    }
}
