using eAgendaMedica.Api.ViewModels.ModuloPaciente;
using eAgendaMedica.Dominio.ModuloPaciente;
using System.Globalization;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloPaciente
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            //CreateMap<O que é, O que eu quero que vire>();
            CreateMap<Paciente, ListarPacienteViewModel>();

            CreateMap<Paciente, VisualizarPacienteViewModel>();

            CreateMap<FormPacienteViewModel, Paciente>()
                .ForMember(paciente => paciente.DataNascimento, opt => opt.MapFrom(pacienteVM => DateTime.ParseExact(pacienteVM.DataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
