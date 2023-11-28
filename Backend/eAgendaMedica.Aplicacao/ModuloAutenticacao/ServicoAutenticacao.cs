using eAgendaMedica.Dominio.ModuloAutenticacao;
using Microsoft.AspNetCore.Identity;

namespace eAgendaMedica.Aplicacao.ModuloAutenticacao
{
    public class ServicoAutenticacao
    {
        private readonly UserManager<Usuario> userManager;

        public ServicoAutenticacao(UserManager<Usuario> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Result<Usuario>> RegistrarAsync(Usuario usuario, string senha)
        {
            IdentityResult resultado =  await userManager.CreateAsync(usuario, senha);

            if(resultado.Succeeded == false)
            {
                return Result.Fail(resultado.Errors.Select(erro => new Error(erro.Description)));
            }

            return Result.Ok(usuario);
        }
    }
}
