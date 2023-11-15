using Serilog;
using System.Text.Json;

namespace eAgendaMedica.Api.Config
{
    public static class SwaggerConfigExtension
    {
        public static void ConfigurarSwaggerExtension(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
