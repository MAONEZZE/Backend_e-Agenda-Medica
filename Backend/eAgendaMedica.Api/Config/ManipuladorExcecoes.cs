using Serilog;
using System.Text.Json;

namespace eAgendaMedica.Api.Config
{
    public class ManipuladorExcecoes : IMiddleware
    {
        public async Task InvokeAsync(HttpContext ctx, RequestDelegate next)
        {
            try
            {
                await next(ctx);
            }
            catch (Exception ex)
            {
                ctx.Response.StatusCode = 500;
                ctx.Response.ContentType = "*application/json";

                var error = new
                {
                    Sucesso = false,
                    Erros = new List<string> { ex.Message }
                };

                Log.Logger.Error(ex, ex.Message);

                ctx.Response.WriteAsync(JsonSerializer.Serialize(error));
            }
        }
    }
}
