namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public interface IRepositorioCirurgia : IRepositorioAtividade<Cirurgia>
    {
        public Task<List<Cirurgia>> SelecionarCirurgiasPassadas();
        public Task<List<Cirurgia>> SelecionarCirurgiasFuturas();
    }
}
