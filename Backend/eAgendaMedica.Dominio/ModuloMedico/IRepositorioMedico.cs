namespace eAgendaMedica.Dominio.ModuloMedico
{
    public interface IRepositorioMedico : IRepositorioBase<Medico>
    {
        public Task<List<Medico>> SelecionarMedicosQueMaisTrabalharam(DateTime dataInicio, DateTime dataFinal);
        public Task<Medico> SelecionarPorCRM(string crm);
        public Task<List<Medico>> SelecionarMuitosAsync(List<Guid> idMedicosSelecionados);
    }
}
