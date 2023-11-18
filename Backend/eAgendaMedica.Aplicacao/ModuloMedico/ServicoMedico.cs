using eAgendaMedica.Dominio.ModuloMedico;
using Serilog;

namespace eAgendaMedica.Aplicacao.ModuloMedico
{
    public class ServicoMedico : ServicoBase<Medico, ValidadorMedico>, IServicoBase<Medico>
    {
        private IRepositorioMedico repMedico;
        private IContextoPersistencia ctxPersistencia;

        public ServicoMedico(IRepositorioMedico repMedico, IContextoPersistencia ctxPersistencia)
        {
            this.repMedico = repMedico;
            this.ctxPersistencia = ctxPersistencia;
        }

        public async Task<Result<Medico>> EditarAsync(Medico registro)
        {
            var resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repMedico.Editar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Medico {registro.Id} editada com sucesso");

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

        public async Task<Result> ExcluirPorRegistroAsync(Medico registro)
        {
            repMedico.Excluir(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Medico {registro.Id} excluido com sucesso");

            return Result.Ok();
        }

        public async Task<Result<Medico>> InserirAsync(Medico registro)
        {
            Result resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            await this.repMedico.InserirAsync(registro);

            await this.ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Medico {registro.Nome} inserido com sucesso");

            return Result.Ok(registro);
        }

        public async Task<Result<Medico>> SelecionarPorIdAsync(Guid id)
        {
            var medico = await repMedico.SelecionarPorIdAsync(id);

            if (medico == null)
            {
                Log.Logger.Warning($"Medico {id} não encontrado");

                return Result.Fail("Medico não encontrado");
            }

            Log.Logger.Information($"Medico {id} selecionado com sucesso");

            return Result.Ok(medico);
        }

        public async Task<Result<List<Medico>>> SelecionarMedicosQueMaisTrabalharam(DateTime dataInicio, DateTime dataFinal)
        {
            var medicos = await repMedico.SelecionarMedicosQueMaisTrabalharam(dataInicio, dataFinal);

            Log.Logger.Information("Medicos que mais trabalharam selecionados com sucesso!");

            return Result.Ok(medicos);
        }

        public async Task<Result<Medico>> SelecionarMedicoPorCrm(string crm)
        {
            var medico = await repMedico.SelecionarPorCRM(crm);

            Log.Logger.Information("Medico selecionado com sucesso!");

            return Result.Ok(medico);
        }

        public async Task<Result<List<Medico>>> SelecionarTodosAsync()
        {
            var medicos = await repMedico.SelecionarTodosAsync();

            Log.Logger.Information("Medicos selecionados com sucesso!");

            return Result.Ok(medicos);
        }
    }
}
