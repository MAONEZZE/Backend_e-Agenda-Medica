using eAgendaMedica.Api.ViewModels.ModuloConsulta;
using eAgendaMedica.Aplicacao.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloConsulta;
using Microsoft.AspNetCore.Authorization;

namespace eAgendaMedica.Api.Controllers.ModuloConsulta
{
    [ApiController]
    [Route("api/consulta")]
    [Authorize]
    public class ConsultaController : ControladorApiBase<ListarConsultaViewModel, FormConsultaViewModel, VisualizarConsultaViewModel, Consulta>
    {
        private readonly ServicoConsulta service;
        private readonly IMapper map;

        public ConsultaController(ServicoConsulta service, IMapper map) : base(service, map)
        {
            this.service = service;
            this.map = map;
        }

        [HttpGet("consultas-para-hoje")]
        [ProducesResponseType(typeof(ListarConsultaViewModel), 200)]
        public async Task<IActionResult> SelecionarConsultasHoje()
        {
            var resultado = await service.SelecionarConsultasParaHoje();

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<List<ListarConsultaViewModel>>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [HttpGet("consultas-futuras")]
        [ProducesResponseType(typeof(ListarConsultaViewModel), 200)]
        public async Task<IActionResult> SelecionarConsultasFuturas()
        {
            var resultado = await service.SelecionarConsultasFuturas();

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<List<ListarConsultaViewModel>>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [HttpGet("consultas-passadas")]
        [ProducesResponseType(typeof(ListarConsultaViewModel), 200)]
        public async Task<IActionResult> SelecionarConsultasPassadas()
        {
            var resultado = await service.SelecionarConsultasPassadas();


            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registrosVM = map.Map<List<ListarConsultaViewModel>>(resultado.Value);

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
        public async override Task<IActionResult> SelecionarPorIdCompleto(Guid id)
        {
            return await base.SelecionarPorIdCompleto(id);
        }

        [ProducesResponseType(typeof(FormConsultaViewModel), 200)]
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
