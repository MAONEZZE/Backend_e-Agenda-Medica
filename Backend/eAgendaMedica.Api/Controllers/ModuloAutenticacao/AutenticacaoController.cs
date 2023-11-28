using eAgendaMedica.Api.ViewModels.ModuloAutenticacao;
using eAgendaMedica.Aplicacao.ModuloAutenticacao;
using eAgendaMedica.Dominio.ModuloAutenticacao;
using FluentResults;
using System.Diagnostics;

namespace eAgendaMedica.Api.Controllers.ModuloAutenticacao
{
    [Route("api/autenticar")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ServicoAutenticacao service;
        private readonly IMapper map;

        public AutenticacaoController(ServicoAutenticacao service, IMapper map)
        {

            this.service = service;
            this.map = map;
        }

        private IActionResult ProcessarResposta(Result<Usuario> resultado, AutenticadorBase usuarioVM = null)
        {
            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            return Ok(new
            {
                Sucesso = true,
                Dados = usuarioVM
            });
        }


        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RegistrarUsuarioViewModel usuarioVM)
        {
            var usuario = this.map.Map<Usuario>(usuarioVM);

            var usuarioResult = await service.RegistrarAsync(usuario, usuarioVM.Senha);

            return ProcessarResposta(usuarioResult, usuarioVM);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AutenticarUsuarioViewModel usuarioVM)
        {
            var usuarioResult = await service.LoginAsync(usuarioVM.Login, usuarioVM.Senha);

            return ProcessarResposta(usuarioResult, usuarioVM);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(AutenticarUsuarioViewModel usuarioVM)
        {
            var usuarioResult = await service.LogoutAsync();

            return Ok();
        }
    }
}
