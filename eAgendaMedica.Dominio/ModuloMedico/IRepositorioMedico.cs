namespace eAgendaMedica.Dominio.ModuloMedico
{
    public interface IRepositorioMedico : IRepositorioBase<Medico>
    {
        public Task<List<Medico>> SelecionarMedicosQueMaisTrabalharam();
        public Task<Medico> VerificarDisponibilidade();
        public Task<Medico> SelecionarPorCRM(string crm);
        public Task<List<Medico>> SelecionarMuitosAsync(List<Guid> idMedicosSelecionados);
    }
}
