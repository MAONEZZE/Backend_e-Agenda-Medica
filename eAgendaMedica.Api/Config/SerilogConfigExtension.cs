using Serilog;

namespace eAgendaMedica.Api.Config
{
    public static class SerilogConfigExtension
    {
        public static void ConfigurarSerilog(this IServiceCollection services, ILoggingBuilder logging)
        {
            logging.ClearProviders();//limpa os provider de log da microsoft

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Iniciando Aplicação...");

            services.AddSerilog(Log.Logger);
        }
    }
}
