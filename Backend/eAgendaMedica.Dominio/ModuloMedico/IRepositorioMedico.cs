namespace eAgendaMedica.Dominio.ModuloMedico
{
    public interface IRepositorioMedico : IRepositorioBase<Medico>
    {
        public Task<List<Medico>> SelecionarMedicosQueMaisTrabalharam(DateTime dataInicio, DateTime dataFinal, Guid usuarioId);
        public Task<Medico> SelecionarPorCRM(string crm, Guid usuarioId);
        public Task<List<Medico>> SelecionarMuitosAsync(List<Guid> idMedicosSelecionados);
    }
}
