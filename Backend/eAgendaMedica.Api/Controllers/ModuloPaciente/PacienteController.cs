using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Api.ViewModels.ModuloPaciente;
using eAgendaMedica.Aplicacao.ModuloPaciente;
using eAgendaMedica.Dominio.ModuloPaciente;

namespace eAgendaMedica.Api.Controllers.ModuloPaciente
{
    [Route("api/paciente")]
    [ApiController]
    public class PacienteController : ControladorApiBase<ListarPacienteViewModel, FormPacienteViewModel, VisualizarPacienteViewModel, Paciente>
    {
        public PacienteController(ServicoPaciente service, IMapper map) : base(service, map)
        {
        }

        [ProducesResponseType(typeof(ListarPacienteViewModel), 200)]
        public async override Task<IActionResult> SelecionarTodos()
        {
            return await base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(VisualizarPacienteViewModel), 200)]
        public async override Task<IActionResult> SelecionarPorIdCompleto(Guid id)
        {
            return await base.SelecionarPorIdCompleto(id);
        }

        [ProducesResponseType(typeof(FormPacienteViewModel), 200)]
        public async override Task<IActionResult> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormPacienteViewModel), 200)]
        public async override Task<IActionResult> Inserir(FormPacienteViewModel registroVM)
        {
            return await base.Inserir(registroVM);
        }

        [ProducesResponseType(typeof(FormPacienteViewModel), 200)]
        public async override Task<IActionResult> Editar(Guid id, FormPacienteViewModel registroVM)
        {
            return await base.Editar(id, registroVM);
        }

        public async override Task<IActionResult> Excluir(Guid id)
        {
            return await base.Excluir(id);
        }
    }
}
