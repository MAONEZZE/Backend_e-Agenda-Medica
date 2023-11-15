using eAgendaMedica.Dominio.ModuloPaciente;
using Serilog;

namespace eAgendaMedica.Aplicacao.ModuloPaciente
{
    public class ServicoPaciente : ServicoBase<Paciente, ValidadorPaciente>, IServicoBase<Paciente>
    {
        private IRepositorioPaciente repPaciente;
        private IContextoPersistencia ctxPersistencia;

        public ServicoPaciente(IRepositorioPaciente repPaciente, IContextoPersistencia ctxPersistencia)
        {
            this.repPaciente = repPaciente;
            this.ctxPersistencia = ctxPersistencia;
        }

        public async Task<Result<Paciente>> EditarAsync(Paciente registro)
        {
            var resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repPaciente.Editar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Paciente {registro.Id} editada com sucesso");

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

        private async Task<Result> Excluir(Paciente registro)
        {
            repPaciente.Excluir(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Paciente {registro.Id} excluido com sucesso");

            return Result.Ok();
        }

        public async Task<Result<Paciente>> InserirAsync(Paciente registro)
        {
            Result resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            await this.repPaciente.InserirAsync(registro);

            await this.ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Paciente {registro.Nome} inserido com sucesso");

            return Result.Ok(registro);
        }

        public async Task<Result<Paciente>> SelecionarPorIdAsync(Guid id)
        {
            var paciente = await repPaciente.SelecionarPorIdAsync(id);

            if (paciente == null)
            {
                Log.Logger.Warning($"Paciente {id} não encontrado");

                return Result.Fail("Paciente não encontrado");
            }

            Log.Logger.Information($"Paciente {id} selecionado com sucesso");

            return Result.Ok(paciente);
        }

        public async Task<Result<List<Paciente>>> SelecionarTodosAsync()
        {
            var pacientes = await repPaciente.SelecionarTodosAsync();

            Log.Logger.Information("Pacientes selecionados com sucesso!");

            return Result.Ok(pacientes);
        }
    }
}
