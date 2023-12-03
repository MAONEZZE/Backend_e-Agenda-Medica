using eAgendaMedica.Dominio.ModuloConsulta;

namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public interface IRepositorioCirurgia : IRepositorioBase<Cirurgia>
    {
        public Task<List<Cirurgia>> SelecionarCirurgiasPassadas(Guid usuarioId);
        public Task<List<Cirurgia>> SelecionarCirurgiasFuturas(Guid usuarioId);
        public Task<List<Cirurgia>> SelecionarCirurgiasParaHoje(Guid usuarioId);
    }
}
