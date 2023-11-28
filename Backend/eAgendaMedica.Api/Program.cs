using eAgendaMedica.Api.Config;
using eAgendaMedica.Api.Config.AutomapperConfig.Compartilhado;
using eAgendaMedica.Api.Config.Excecoes;
using eAgendaMedica.Api.Filters;
using eAgendaMedica.Dominio.ModuloAutenticacao;
using eAgendaMedica.Infra.Compartilhado;
using Microsoft.AspNetCore.Identity;

namespace eAgendaMedica.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            builder.Services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = false;//serve para mascarar o erro
            });

            //============== Logs =================
            builder.Services.ConfigurarSerilog(builder.Logging);
            //=====================================

            //============ Extension ==============
            builder.Services.ConfigurarSwaggerExtension();
            builder.Services.ConfigurarInjecaoDependencia(builder.Configuration);

            builder.Services.AddIdentity<Usuario, IdentityRole<Guid>>(opt =>
                {
                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<eAgendaMedicaDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<eAgendaErrorDescriber>();
            //=====================================

            //============= Mappers ===============
            builder.Services.ConfigurarAutoMapper();
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

            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}