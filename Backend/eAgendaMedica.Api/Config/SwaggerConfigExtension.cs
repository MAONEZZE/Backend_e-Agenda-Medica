using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace eAgendaMedica.Api.Config
{
    public static class SwaggerConfigExtension
    {
        public static void ConfigurarSwaggerExtension(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });

                x.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("2023-11-20")
                });
            });
        }
    }
}
