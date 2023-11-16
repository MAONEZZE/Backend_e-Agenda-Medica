using eAgendaMedica.Api.Config;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace eAgendaMedica.Api.Filters
{
    public class SerilogActionFilter : IActionFilter
    {
        private object endpoint;//fica salvo na memoria do request, por isso consegue reutilizar em mais metodos com o mesmo valor 
        private object modulo;

        public string Endpoint
        {
            get
            {
                return this.endpoint.ToString().SepararPalavraPorMaiusculas();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)//enquanto executa os controllers 
        {
            endpoint = context.RouteData.Values["action"]; //aqui pega o nome do endpoint

            modulo = context.RouteData.Values["controller"]; //aqui pega o nome do modulo

            Log.Logger.Information($"[Módulo de {modulo}] -> Tentando {Endpoint}...");
        }

        public void OnActionExecuted(ActionExecutedContext context)//apos os controllers serem executados
        {
            if (context.Exception != null)
            {
                Log.Logger.Information($"[Módulo de {modulo}] -> Falha ao executar {Endpoint}");
                return;
            }

            Log.Logger.Information($"[Módulo de {modulo}] -> {Endpoint} executado com sucesso!");
        }

    }
}
