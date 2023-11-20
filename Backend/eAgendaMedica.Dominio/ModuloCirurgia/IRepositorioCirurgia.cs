using eAgendaMedica.Dominio.ModuloConsulta;

namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public interface IRepositorioCirurgia : IRepositorioBase<Cirurgia>
    {
        public Task<List<Cirurgia>> SelecionarCirurgiasPassadasComDataAlvo(DateTime dataAlvo);
        public Task<List<Cirurgia>> SelecionarCirurgiasFuturasComDataAlvo(DateTime dataAlvo);
        public Task<List<Cirurgia>> SelecionarCirurgiasParaHoje();
    }
}
