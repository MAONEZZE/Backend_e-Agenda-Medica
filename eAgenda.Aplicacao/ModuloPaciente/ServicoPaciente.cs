using eAgendaMedica.Dominio.ModuloPaciente;

namespace eAgendaMedica.Aplicacao.ModuloPaciente
{
    public class ServicoPaciente : ServicoBase<Paciente, ValidadorPaciente>, IServicoBase<Paciente>
    {
        public Task<Result<Paciente>> EditarAsync(Paciente registro)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Paciente registro)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Paciente>> InserirAsync(Paciente registro)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Paciente>> SelecionarPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Paciente>>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
