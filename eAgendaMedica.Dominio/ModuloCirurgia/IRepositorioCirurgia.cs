namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public interface IRepositorioCirurgia : IRepositorioBase<Cirurgia>
    {
        public Task<List<Cirurgia>> SelecionarCirurgiasPassadas();
        public Task<List<Cirurgia>> SelecionarCirurgiasFuturas();
    }
}
