using eAgendaMedica.Aplicacao.ModuloAutenticacao;
using eAgendaMedica.Dominio.ModuloAutenticacao;

namespace eAgendaMedica.Api.Controllers.ModuloAutenticacao
{
    [Route("api/registrar")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private ServicoAutenticacao service;

        public AutenticacaoController(ServicoAutenticacao service)
        {

            this.service = service;

        }

        [HttpPost]
        public async Task<IActionResult> Registrar()
        {
            var user = new Usuario
            {
                Nome = "ruan sanchez",
                Email = "ruan@gmail.com",
                UserName = "ruan",
                PasswordHash = "Ruan@123"
            };

            await service.RegistrarAsync(user, user.PasswordHash);

            return Ok(user);
        }
    }
}
