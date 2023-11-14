using eAgendaMedica.Dominio.ModuloConsulta;
using Serilog;

namespace eAgendaMedica.Aplicacao.ModuloConsulta
{
    public class ServicoConsulta : ServicoBase<Consulta, ValidadorConsulta>, IServicoBase<Consulta>
    {
        private IRepositorioConsulta repConsulta;
        private IContextoPersistencia ctxPersistencia;

        public ServicoConsulta(IRepositorioConsulta repConsulta, IContextoPersistencia ctxPersistencia)
        {
            this.repConsulta = repConsulta;
            this.ctxPersistencia = ctxPersistencia;
        }

        public Task<Result<Consulta>> EditarAsync(Consulta registro)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Consulta registro)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Consulta>> InserirAsync(Consulta registro)
        {
            Result resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }



            await this.repConsulta.InserirAsync(registro);

            await this.ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Consulta {registro.Titulo} inserida com sucesso");

            return Result.Ok(registro);
        }

        public Task<Result<Consulta>> SelecionarPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Consulta>>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
