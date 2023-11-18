using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;
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

        public async Task<Result> ExcluirPorIdAsync(Guid id)
        {
            var resultado = await SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            return await ExcluirPorRegistroAsync(resultado.Value);
        }

        public async Task<Result> ExcluirPorRegistroAsync(Cirurgia registro)
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

        public async Task<Result<List<Cirurgia>>> SelecionarCirurgiasFuturas(DateTime data)
        {
            var cirurgia = await repCirurgia.SelecionarCirurgiasFuturasComDataAlvo(data);

            Log.Logger.Information("Cirurgias futuras selecionadas com sucesso!");

            return Result.Ok(cirurgia);
        }

        public async Task<Result<List<Cirurgia>>> SelecionarCirurgiasPassadas(DateTime data)
        {
            var cirurgia = await repCirurgia.SelecionarCirurgiasPassadasComDataAlvo(data);

            Log.Logger.Information("Cirurgias passadas selecionadas com sucesso!");

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
