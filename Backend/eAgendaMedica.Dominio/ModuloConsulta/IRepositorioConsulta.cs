using eAgendaMedica.Dominio.ModuloCirurgia;

namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public interface IRepositorioConsulta : IRepositorioBase<Consulta>
    {
        public Task<List<Consulta>> SelecionarConsultasPassadasComDataAlvo(DateTime dataAlvo);
        public Task<List<Consulta>> SelecionarConsultasFuturasComDataAlvo(DateTime dataAlvo);
        public Task<List<Consulta>> SelecionarConsultasParaHoje();
    }
}
