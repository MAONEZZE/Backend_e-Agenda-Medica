using eAgendaMedica.Api.ViewModels.ModuloConsulta;
using eAgendaMedica.Aplicacao.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloConsulta;

namespace eAgendaMedica.Api.Controllers.ModuloConsulta
{
    [Route("api/consulta")]
    [ApiController]
    public class ConsultaController : ControladorApiBase<ListarConsultaViewModel, FormConsultaViewModel, VisualizarConsultaViewModel, Consulta>
    {
        public ConsultaController(ServicoConsulta service, IMapper map) : base(service, map)
        {
        }

        [ProducesResponseType(typeof(ListarConsultaViewModel), 200)]
        public override Task<IActionResult> SelecionarTodos()
        {
            return base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(VisualizarConsultaViewModel), 200)]
        public override Task<IActionResult> SelecionarPorId(Guid id)
        {
            return base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormConsultaViewModel), 200)]
        public override Task<IActionResult> Inserir(FormConsultaViewModel registroVM)
        {
            return base.Inserir(registroVM);
        }

        [ProducesResponseType(typeof(FormConsultaViewModel), 200)]
        public override Task<IActionResult> Editar(Guid id, FormConsultaViewModel registroVM)
        {
            return base.Editar(id, registroVM);
        }

        public override Task<IActionResult> Excluir(Guid id)
        {
            return base.Excluir(id);
        }
    }
}
