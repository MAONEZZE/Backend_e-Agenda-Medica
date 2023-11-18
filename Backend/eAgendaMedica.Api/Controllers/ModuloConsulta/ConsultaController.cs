using eAgendaMedica.Api.ViewModels.ModuloConsulta;
using eAgendaMedica.Aplicacao.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloConsulta;

namespace eAgendaMedica.Api.Controllers.ModuloConsulta
{
    [Route("api/consulta")]
    [ApiController]
    public class ConsultaController : ControladorApiBase<ListarConsultaViewModel, FormConsultaViewModel, VisualizarConsultaViewModel, Consulta>
    {
        private readonly ServicoConsulta service;
        private readonly IMapper map;

        public ConsultaController(ServicoConsulta service, IMapper map) : base(service, map)
        {
            this.service = service;
            this.map = map;
        }

        [HttpGet("consultas-futuras/{data}")]
        [ProducesResponseType(typeof(ListarConsultaViewModel), 200)]
        public async Task<IActionResult> SelecionarConsultasFuturas(DateTime data)
        {
            var resultado = await service.SelecionarConsultasFuturas(data);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<ListarConsultaViewModel>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [HttpGet("consultas-passadas/{data}")]
        [ProducesResponseType(typeof(ListarConsultaViewModel), 200)]
        public async Task<IActionResult> SelecionarConsultasPassadas(DateTime data)
        {
            var resultado = await service.SelecionarConsultasPassadas(data);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<ListarConsultaViewModel>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [ProducesResponseType(typeof(ListarConsultaViewModel), 200)]
        public async override Task<IActionResult> SelecionarTodos()
        {
            return await base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(VisualizarConsultaViewModel), 200)]
        public async override Task<IActionResult> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormConsultaViewModel), 200)]
        public async override Task<IActionResult> Inserir(FormConsultaViewModel registroVM)
        {
            return await base.Inserir(registroVM);
        }

        [ProducesResponseType(typeof(FormConsultaViewModel), 200)]
        public async override Task<IActionResult> Editar(Guid id, FormConsultaViewModel registroVM)
        {
            return await base.Editar(id, registroVM);
        }

        public async override Task<IActionResult> Excluir(Guid id)
        {
            return await base.Excluir(id);
        }
    }
}
