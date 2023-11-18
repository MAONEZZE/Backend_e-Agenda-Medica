using eAgendaMedica.Api.ViewModels.ModuloCirurgia;
using eAgendaMedica.Api.ViewModels.ModuloConsulta;
using eAgendaMedica.Aplicacao.ModuloCirurgia;
using eAgendaMedica.Aplicacao.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloCirurgia;


namespace eAgendaMedica.Api.Controllers.ModuloCirurgia
{
    [Route("api/cirurgia")]
    [ApiController]
    public class CirurgiaController : ControladorApiBase<ListarCirurgiaViewModel, FormCirurgiaViewModel, VisualizarCirurgiaViewModel, Cirurgia>
    {
        private readonly ServicoCirurgia service;
        private readonly IMapper map;

        public CirurgiaController(ServicoCirurgia service, IMapper map) : base(service, map)
        {
            this.service = service;
            this.map = map;
        }

        [HttpGet("cirurgias-futuras/{data}")]
        [ProducesResponseType(typeof(ListarCirurgiaViewModel), 200)]
        public async Task<IActionResult> SelecionarCirurgiasFuturas(DateTime data)
        {
            var resultado = await service.SelecionarCirurgiasFuturas(data);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<ListarCirurgiaViewModel>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [HttpGet("cirurgias-passadas/{data}")]
        [ProducesResponseType(typeof(ListarCirurgiaViewModel), 200)]
        public async Task<IActionResult> SelecionarConsultasPassadas(DateTime data)
        {
            var resultado = await service.SelecionarCirurgiasPassadas(data);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<ListarCirurgiaViewModel>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [ProducesResponseType(typeof(ListarCirurgiaViewModel), 200)]
        public async override Task<IActionResult> SelecionarTodos()
        {
            return await base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(VisualizarCirurgiaViewModel), 200)]
        public async override Task<IActionResult> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormCirurgiaViewModel), 200)]
        public async override Task<IActionResult> Inserir(FormCirurgiaViewModel registroVM)
        {
            return await base.Inserir(registroVM);
        }

        [ProducesResponseType(typeof(FormCirurgiaViewModel), 200)]
        public async override Task<IActionResult> Editar(Guid id, FormCirurgiaViewModel registroVM)
        {
            return await base.Editar(id, registroVM);
        }

        public async override Task<IActionResult> Excluir(Guid id)
        {
            return await base.Excluir(id);
        }
    }
}
