using eAgendaMedica.Dominio.ModuloCirurgia;
using Serilog;

namespace eAgendaMedica.Aplicacao.ModuloCirurgia
{
    public class ServicoCirurgia : ServicoBase<Cirurgia, ValidadorCirurgia>, IServicoBase<Cirurgia>
    {
        private IRepositorioCirurgia repCirurgia;
        private IContextoPersistencia ctxPersistencia;

        public ServicoCirurgia(IRepositorioCirurgia repCirurgia, IContextoPersistencia ctxPersistencia)
        {
            this.repCirurgia = repCirurgia;
            this.ctxPersistencia = ctxPersistencia;
        }

        public async Task<Result<Cirurgia>> EditarAsync(Cirurgia registro)
        {
            var resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repCirurgia.Editar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Cirurgia {registro.Id} editada com sucesso");

            return Result.Ok(registro);
        }

        public async Task<Result> ExcluirAsync(Guid id)
        {
            var resultado = await SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            return await Excluir(resultado.Value);
        }

        private async Task<Result> Excluir(Cirurgia registro)
        {
            repCirurgia.Excluir(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Cirurgia {registro.Id} excluido com sucesso");

            return Result.Ok();
        }

        public async Task<Result<Cirurgia>> InserirAsync(Cirurgia registro)
        {
            Result resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            await this.repCirurgia.InserirAsync(registro);

            await this.ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Cirurgia {registro.Titulo} inserida com sucesso");

            return Result.Ok(registro);
        }

        public async Task<Result<Cirurgia>> SelecionarPorIdAsync(Guid id)
        {
            var cirurgia = await repCirurgia.SelecionarPorIdAsync(id);

            if (cirurgia == null)
            {
                Log.Logger.Warning($"Cirurgia {id} não encontrado");

                return Result.Fail("Cirurgia não encontrada");
            }

            Log.Logger.Information($"Cirurgia {id} selecionado com sucesso");

            return Result.Ok(cirurgia);
        }

        public async Task<Result<List<Cirurgia>>> SelecionarTodosAsync()
        {
            var cirurgias = await repCirurgia.SelecionarTodosAsync();

            Log.Logger.Information("Cirurgias selecionadas com sucesso!");

            return Result.Ok(cirurgias);
        }
    }
}
