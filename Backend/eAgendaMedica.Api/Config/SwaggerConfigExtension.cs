using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Xml;

namespace eAgendaMedica.Api.Config
{
    public static class SwaggerConfigExtension
    {
        public static void ConfigurarSwaggerExtension(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "eAgendaMedica.WebApi", Version = "v1" });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,// onde a informação vai ser passada
                    Description = "Por favor informe o token {Bearer token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

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
