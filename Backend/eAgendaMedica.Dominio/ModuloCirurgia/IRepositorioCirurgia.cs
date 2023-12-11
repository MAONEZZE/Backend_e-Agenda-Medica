using eAgendaMedica.Dominio.ModuloConsulta;

namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public interface IRepositorioCirurgia : IRepositorioBase<Cirurgia>
    {
        public Task<List<Cirurgia>> SelecionarCirurgiasPassadas();
        public Task<List<Cirurgia>> SelecionarCirurgiasFuturas();
        public Task<List<Cirurgia>> SelecionarCirurgiasParaHoje();
    }
}
