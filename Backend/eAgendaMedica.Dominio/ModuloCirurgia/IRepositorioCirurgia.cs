using eAgendaMedica.Dominio.ModuloConsulta;

namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public interface IRepositorioCirurgia : IRepositorioBase<Cirurgia>
    {
        public Task<List<Cirurgia>> SelecionarCirurgiasPassadasComDataAlvo();
        public Task<List<Cirurgia>> SelecionarCirurgiasFuturasComDataAlvo();
        public Task<List<Cirurgia>> SelecionarCirurgiasParaHoje();
    }
}
