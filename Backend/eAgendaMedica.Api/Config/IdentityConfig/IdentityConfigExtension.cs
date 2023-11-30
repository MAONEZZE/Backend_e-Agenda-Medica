using eAgendaMedica.Aplicacao.ModuloAutenticacao;
using eAgendaMedica.Dominio.ModuloAutenticacao;
using eAgendaMedica.Infra.Compartilhado;
using Microsoft.AspNetCore.Identity;

namespace eAgendaMedica.Api.Config.IdentityConfig
{
    public static class IdentityConfigExtension
    {
        public static void ConfigurarIdentity(this IServiceCollection services)
        {
            services.AddTransient<ServicoAutenticacao>();

            services.AddIdentity<Usuario, IdentityRole<Guid>>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<eAgendaMedicaDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<eAgendaErrorDescriber>();
        }
    }
}
