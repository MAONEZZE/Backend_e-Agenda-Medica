using eAgendaMedica.Dominio.ModuloCirurgia;

namespace eAgendaMedica.Aplicacao.ModuloCirurgia
{
    public class ServicoCirurgia : ServicoBase<Cirurgia, ValidadorCirurgia>, IServicoBase<Cirurgia>
    {
        public Task<Result<Cirurgia>> EditarAsync(Cirurgia registro)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Cirurgia registro)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Cirurgia>> InserirAsync(Cirurgia registro)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Cirurgia>> SelecionarPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Cirurgia>>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
