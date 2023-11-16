using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Aplicacao.ModuloMedico;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Api.Controllers.ModuloMedico
{
    [Route("api/medico")]
    [ApiController]
    public class MedicoController : ControladorApiBase<ListarMedicoViewModel, FormMedicoViewModel, VisualizarMedicoViewModel, Medico>
    {
        public MedicoController(ServicoMedico service, IMapper map) : base(service, map)
        {
        }

        [ProducesResponseType(typeof(ListarMedicoViewModel), 200)]
        public override Task<IActionResult> SelecionarTodos()
        {
            return base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(VisualizarMedicoViewModel), 200)]
        public override Task<IActionResult> SelecionarPorId(Guid id)
        {
            return base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormMedicoViewModel), 200)]
        public override Task<IActionResult> Inserir(FormMedicoViewModel registroVM)
        {
            return base.Inserir(registroVM);
        }

        [ProducesResponseType(typeof(FormMedicoViewModel), 200)]
        public override Task<IActionResult> Editar(Guid id, FormMedicoViewModel registroVM)
        {
            return base.Editar(id, registroVM);
        }

        public override Task<IActionResult> Excluir(Guid id)
        {
            return base.Excluir(id);
        }
    }
}
