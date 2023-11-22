using eAgendaMedica.Api.Config.AutomapperConfig.ModuloCirurgia;
using eAgendaMedica.Api.ViewModels.ModuloCirurgia;
using eAgendaMedica.Api.ViewModels.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloPaciente;
using System.Globalization;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloConsulta
{
    public class ConsultaProfile : Profile
    {
        public ConsultaProfile()
        {
            //CreateMap<O que é, O que vai virar>();
            CreateMap<Consulta, ListarConsultaViewModel>()
                .ForMember(consultaVM => consultaVM.Data, opt => opt.MapFrom(consulta => consulta.Data.ToShortDateString()))
                .ForMember(consultaVM => consultaVM.HoraInicio, opt => opt.MapFrom(consulta => consulta.HoraInicio.ToString(@"hh\:mm")));

            CreateMap<Consulta, VisualizarConsultaViewModel>()
                .ForMember(consultaVM => consultaVM.Data, opt => opt.MapFrom(consulta => consulta.Data.ToShortDateString()))
                .ForMember(consultaVM => consultaVM.HoraInicio, opt => opt.MapFrom(consulta => consulta.HoraInicio.ToString(@"hh\:mm")))
                .ForMember(consultaVM => consultaVM.HoraTermino, opt => opt.MapFrom(consulta => consulta.HoraTermino.ToString(@"hh\:mm")));

            CreateMap<FormConsultaViewModel, Consulta>()
                .AfterMap<InserirMedicoConsultaMappingAction>()
                .AfterMap<InserirPacienteConsultaMappingAction>();

            CreateMap<Consulta, FormConsultaViewModel>();
        }
    }
}
