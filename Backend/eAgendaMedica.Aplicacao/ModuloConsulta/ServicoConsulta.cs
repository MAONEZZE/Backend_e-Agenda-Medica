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

        public async Task<Result<Consulta>> EditarAsync(Consulta registro)
        {
            registro.Data = registro.Data.Date;

            var resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repConsulta.Editar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Consulta {registro.Id} editada com sucesso");

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

        public async Task<Result> ExcluirPorRegistroAsync(Consulta registro)
        {
            repConsulta.Excluir(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Consulta {registro.Id} excluido com sucesso");

            return Result.Ok();
        }

        public async Task<Result<Consulta>> InserirAsync(Consulta registro)
        {
            registro.Data = registro.Data.Date;

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

        public async Task<Result<Consulta>> SelecionarPorIdAsync(Guid id)
        {
            var consulta = await repConsulta.SelecionarPorIdAsync(id);

            if (consulta == null)
            {
                Log.Logger.Warning($"Consulta {id} não encontrado");

                return Result.Fail("Consulta não encontrada");
            }

            Log.Logger.Information($"Consulta {id} selecionado com sucesso");

            return Result.Ok(consulta);
        }

        public async Task<Result<List<Consulta>>> SelecionarConsultasParaHoje()
        {
            var consultas = await repConsulta.SelecionarConsultasParaHoje();

            Log.Logger.Information("Consultas de hoje selecionadas com sucesso!");

            return Result.Ok(consultas);
        }

        public async Task<Result<List<Consulta>>> SelecionarConsultasFuturas()
        {
            
            var consultas = await repConsulta.SelecionarConsultasFuturasComDataAlvo();

            Log.Logger.Information("Consultas futuras selecionadas com sucesso!");

            return Result.Ok(consultas);
            
        }

        public async Task<Result<List<Consulta>>> SelecionarConsultasPassadas()
        {

            var consultas = await repConsulta.SelecionarConsultasPassadasComDataAlvo();

            Log.Logger.Information("Consultas passadas selecionadas com sucesso!");

            return Result.Ok(consultas);
            
        }

        public async Task<Result<List<Consulta>>> SelecionarTodosAsync()
        {
            var consultas = await repConsulta.SelecionarTodosAsync();

            Log.Logger.Information("Consultas selecionadas com sucesso!");

            return Result.Ok(consultas);
        }
    }
}
