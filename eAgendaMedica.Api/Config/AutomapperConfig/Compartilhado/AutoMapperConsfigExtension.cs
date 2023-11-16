using eAgendaMedica.Api.Config.AutomapperConfig.ModuloCirurgia;
using eAgendaMedica.Api.Config.AutomapperConfig.ModuloConsulta;
using eAgendaMedica.Api.Config.AutomapperConfig.ModuloMedico;
using eAgendaMedica.Api.Config.AutomapperConfig.ModuloPaciente;

namespace eAgendaMedica.Api.Config.AutomapperConfig.Compartilhado
{
    public static class AutoMapperConsfigExtension
    {
        public static void ConfigurarAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile<CirurgiaProfile>();
                opt.AddProfile<ConsultaProfile>();
                opt.AddProfile<MedicoProfile>();
                opt.AddProfile<PacienteProfile>();
            });
        }
    }
}
