using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Aplicacao.ModuloMedico
{
    public class ServicoMedico : ServicoBase<Medico, ValidadorMedico>, IServicoBase<Medico>
    {
        public Task<Result<Medico>> EditarAsync(Medico registro)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Medico registro)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Medico>> InserirAsync(Medico registro)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Medico>> SelecionarPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Medico>>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
