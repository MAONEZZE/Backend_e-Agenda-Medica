namespace eAgendaMedica.Dominio.ModuloMedico
{
    public interface IRepositorioMedico : IRepositorioBase<Medico>
    {
        public Task<List<Medico>> SelecionarMedicosQueMaisTrabalharam();
        public Task<Medico> VerificarDisponibilidade(string horarioEsperado);
        public Task<Medico> SelecionarPorCRM(string crm);
    }
}
