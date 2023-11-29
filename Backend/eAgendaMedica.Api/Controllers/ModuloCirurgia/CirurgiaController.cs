using eAgendaMedica.Api.ViewModels.ModuloCirurgia;
using eAgendaMedica.Aplicacao.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloCirurgia;
using Microsoft.AspNetCore.Authorization;

namespace eAgendaMedica.Api.Controllers.ModuloCirurgia
{
    [ApiController]
    [Route("api/cirurgia")]
    [Authorize]
    public class CirurgiaController : ControladorApiBase<ListarCirurgiaViewModel, FormCirurgiaViewModel, VisualizarCirurgiaViewModel, Cirurgia>
    {
        private readonly ServicoCirurgia service;
        private readonly IMapper map;

        public CirurgiaController(ServicoCirurgia service, IMapper map) : base(service, map)
        {
            this.service = service;
            this.map = map;
        }

        [HttpGet("cirurgias-para-hoje")]
        [ProducesResponseType(typeof(ListarCirurgiaViewModel), 200)]
        public async Task<IActionResult> SelecionarCirurgiasHoje()
        {
            var resultado = await service.SelecionarCirurgiasParaHoje();

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<List<ListarCirurgiaViewModel>>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [HttpGet("cirurgias-futuras")]
        [ProducesResponseType(typeof(ListarCirurgiaViewModel), 200)]
        public async Task<IActionResult> SelecionarCirurgiasFuturas()
        {
            var resultado = await service.SelecionarCirurgiasFuturas();

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<List<ListarCirurgiaViewModel>>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [HttpGet("cirurgias-passadas")]
        [ProducesResponseType(typeof(ListarCirurgiaViewModel), 200)]
        public async Task<IActionResult> SelecionarConsultasPassadas()
        {
            var resultado = await service.SelecionarCirurgiasPassadas();

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<List<ListarCirurgiaViewModel>>(resultado.Value);

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
        public async override Task<IActionResult> SelecionarPorIdCompleto(Guid id)
        {
            return await base.SelecionarPorIdCompleto(id);
        }

        [ProducesResponseType(typeof(FormCirurgiaViewModel), 200)]
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
