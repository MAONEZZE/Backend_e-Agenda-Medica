using eAgendaMedica.Api.ViewModels.ModuloPaciente;
using eAgendaMedica.Dominio.ModuloPaciente;

namespace eAgendaMedica.Api.Controllers.ModuloPaciente
{
    [Route("api/paciente")]
    [ApiController]
    public class PacienteController : ControladorApiBase<ListarPacienteViewModel, FormPacienteViewModel, VisualizarPacienteViewModel, Paciente>
    {
        public PacienteController(IServicoBase<Paciente> service, IMapper map) : base(service, map)
        {
        }

        [ProducesResponseType(typeof(ListarPacienteViewModel), 200)]
        public override Task<IActionResult> SelecionarTodos()
        {
            return base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(VisualizarPacienteViewModel), 200)]
        public override Task<IActionResult> SelecionarPorId(Guid id)
        {
            return base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormPacienteViewModel), 200)]
        public override Task<IActionResult> Inserir(FormPacienteViewModel registroVM)
        {
            return base.Inserir(registroVM);
        }

        [ProducesResponseType(typeof(FormPacienteViewModel), 200)]
        public override Task<IActionResult> Editar(Guid id, FormPacienteViewModel registroVM)
        {
            return base.Editar(id, registroVM);
        }

        [ProducesResponseType(200)]
        public override Task<IActionResult> Excluir(Guid id)
        {
            return base.Excluir(id);
        }
    }
}
