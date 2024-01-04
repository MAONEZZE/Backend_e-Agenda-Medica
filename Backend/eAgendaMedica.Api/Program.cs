using eAgendaMedica.Api.Config;
using eAgendaMedica.Api.Config.AutomapperConfig.Compartilhado;
using eAgendaMedica.Api.Config.IdentityConfig;
using eAgendaMedica.Api.Config.TokenConfig;
using eAgendaMedica.Api.Filters;

namespace eAgendaMedica.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            builder.Services.ConfigurarValidacao();

            //============== Logs =================
            builder.Services.ConfigurarSerilog(builder.Logging);
            //=====================================

            //============ Extension ==============
            builder.Services.ConfigurarSwaggerExtension();
            builder.Services.ConfigurarInjecaoDependencia(builder.Configuration);

            builder.Services.ConfigurarIdentity();
            //=====================================

            //============= Mappers ===============
            builder.Services.ConfigurarAutoMapper();
            //=====================================

            //======= Autenticação Config ========= 
            builder.Services.ConfigurarValidacaoToken(); //configuração do middleware que ira validar o token, a partir de qualquer request
            //=====================================

            //== Controllers, Filtros e Exceções ==
            builder.Services.AddControllers(config =>
            {
                config.Filters.Add<SerilogActionFilter>();
            });

            var app = builder.Build();

            app.UseMiddleware<ManipuladorExcecoes>();
            //=====================================

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}