using eAgendaMedica.Api.Config;
using eAgendaMedica.Api.Filters;

namespace eAgendaMedica.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });

            //============== Logs =================
            builder.Services.ConfigurarSerilog(builder.Logging);
            //=====================================

            //============ Extension ==============
            builder.Services.ConfigurarSwaggerExtension();
            builder.Services.ConfigurarInjecaoDependencia(builder.Configuration);
            //=====================================

            //============= Mappers ===============
            //builder.Services.ConfigurarAutoMapper();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}