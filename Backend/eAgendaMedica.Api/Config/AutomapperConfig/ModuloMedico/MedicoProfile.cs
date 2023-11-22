using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloMedico
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            //CreateMap<O que é, O que vai virar>();
            CreateMap<Medico, ListarMedicoViewModel>();

            CreateMap<Medico, VisualizarMedicoViewModel>();

            CreateMap<FormMedicoViewModel, Medico>();

            CreateMap<Medico, FormMedicoViewModel>();
        }
    }
}
