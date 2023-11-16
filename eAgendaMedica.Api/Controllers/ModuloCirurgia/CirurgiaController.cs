using eAgendaMedica.Api.ViewModels.ModuloCirurgia;
using eAgendaMedica.Aplicacao.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloCirurgia;


namespace eAgendaMedica.Api.Controllers.ModuloCirurgia
{
    [Route("api/cirurgia")]
    [ApiController]
    public class CirurgiaController : ControladorApiBase<ListarCirurgiaViewModel, FormCirurgiaViewModel, VisualizarCirurgiaViewModel, Cirurgia>
    {
        public CirurgiaController(ServicoCirurgia service, IMapper map) : base(service, map)
        {
        }

        [ProducesResponseType(typeof(ListarCirurgiaViewModel), 200)]
        public override Task<IActionResult> SelecionarTodos()
        {
            return base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(VisualizarCirurgiaViewModel), 200)]
        public override Task<IActionResult> SelecionarPorId(Guid id)
        {
            return base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormCirurgiaViewModel), 200)]
        public override Task<IActionResult> Inserir(FormCirurgiaViewModel registroVM)
        {
            return base.Inserir(registroVM);
        }

        [ProducesResponseType(typeof(FormCirurgiaViewModel), 200)]
        public override Task<IActionResult> Editar(Guid id, FormCirurgiaViewModel registroVM)
        {
            return base.Editar(id, registroVM);
        }

        public override Task<IActionResult> Excluir(Guid id)
        {
            return base.Excluir(id);
        }
    }
}
