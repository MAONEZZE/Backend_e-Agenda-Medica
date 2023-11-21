using eAgendaMedica.Api.ViewModels.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloPaciente;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloConsulta
{
    public class InserirPacienteConsultaMappingAction : IMappingAction<FormConsultaViewModel, Consulta>
    {
        private readonly IRepositorioPaciente repPaciente;

        public InserirPacienteConsultaMappingAction(IRepositorioPaciente repPaciente)
        {
            this.repPaciente = repPaciente;
        }

        public void Process(FormConsultaViewModel consultaVM, Consulta consulta, ResolutionContext ctx)
        {
            consulta.PacienteAtributo = repPaciente.SelecionarPorIdAsync(consultaVM.Paciente_id).Result;
        }
    }
}
