using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Aplicacao.ModuloMedico;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Api.Controllers.ModuloMedico
{
    [Route("api/medico")]
    [ApiController]
    public class MedicoController : ControladorApiBase<ListarMedicoViewModel, FormMedicoViewModel, VisualizarMedicoViewModel, Medico>
    {
        private readonly ServicoMedico service;
        private readonly IMapper map;

        public MedicoController(ServicoMedico service, IMapper map) : base(service, map)
        {
            this.service = service;
            this.map = map;
        }

        [HttpGet("medico-mais-trabalhadores")]
        [ProducesResponseType(typeof(ListarMedicoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarMedicosQueMaisTrabalham(DateTime dataInicio, DateTime dataFinal)
        {
            var resultado = await service.SelecionarMedicosQueMaisTrabalharam(dataInicio, dataFinal);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            List<ListarMedicoViewModel> registrosVM = this.map.Map<List<ListarMedicoViewModel>>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [HttpGet("selecionar-por-crm/{crm}")]
        [ProducesResponseType(typeof(VisualizarMedicoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarMedicoPorCrm(string crm)
        {
            var resultado = await service.SelecionarMedicoPorCrm(crm);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            VisualizarMedicoViewModel registrosVM = this.map.Map<VisualizarMedicoViewModel>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [ProducesResponseType(typeof(ListarMedicoViewModel), 200)]
        public async override Task<IActionResult> SelecionarTodos()
        {
            return await base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(VisualizarMedicoViewModel), 200)]
        public async override Task<IActionResult> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormMedicoViewModel), 200)]
        public async override Task<IActionResult> Inserir(FormMedicoViewModel registroVM)
        {
            return await base.Inserir(registroVM);
        }

        [HttpPut("editar-por-crm/{crm}")]
        public async Task<IActionResult> EditaPorCrm(string crm, FormMedicoViewModel medicoVM)
        {
            var resultado = await service.SelecionarMedicoPorCrm(crm);

            if (resultado.IsFailed)
            {
                return NotFound(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            Medico medico = map.Map(medicoVM, resultado.Value);

            var resultadoEdit = await service.EditarAsync(medico);

            return base.ProcessarResposta(resultadoEdit, medicoVM);
        }

        [ProducesResponseType(typeof(FormMedicoViewModel), 200)]
        public async override Task<IActionResult> Editar(Guid id, FormMedicoViewModel registroVM)
        {
            return await base.Editar(id, registroVM);
        }

        public async override Task<IActionResult> Excluir(Guid id)
        {
            return await base.Excluir(id);
        }
    }
}
