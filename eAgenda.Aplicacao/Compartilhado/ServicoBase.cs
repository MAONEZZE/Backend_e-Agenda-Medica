using FluentValidation;
using FluentValidation.Results;
using Serilog;

namespace eAgendaMedica.Aplicacao.Compartilhado
{
    public abstract class ServicoBase<TEntity, TValidador>
        where TEntity : EntidadeBase<TEntity>
        where TValidador : AbstractValidator<TEntity>, new()
    {
        protected virtual Result Validar(TEntity registro)
        {
            var validador = new TValidador();

            var resultado = validador.Validate(registro);

            var erros = new List<Error>();

            foreach(ValidationFailure err in resultado.Errors)
            {
                Log.Logger.Warning(err.ErrorMessage);

                erros.Add(new Error(err.ErrorMessage));
            }

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
        }
    }
}
