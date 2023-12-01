using eAgendaMedica.Dominio.ModuloAutenticacao;
using Microsoft.AspNetCore.Identity;

namespace eAgendaMedica.Aplicacao.ModuloAutenticacao
{
    public class ServicoAutenticacao : ServicoBase<Usuario, ValidadorUsuario>
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> sign;

        public ServicoAutenticacao(UserManager<Usuario> userManager, SignInManager<Usuario> sign)
        {
            this.userManager = userManager;
            this.sign = sign;
        }

        public async Task<Result<Usuario>> RegistrarAsync(Usuario usuario, string senha)
        {
            Result resultado = Validar(usuario);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            var usuarioEncontrado = await userManager.FindByEmailAsync(usuario.Email);

            if (usuarioEncontrado != null)
            {
                return Result.Fail($"e-mail {usuarioEncontrado.Email} já cadastrado");
            }

            IdentityResult usuarioResult =  await userManager.CreateAsync(usuario, senha);

            if(usuarioResult.Succeeded == false)
            {
                return Result.Fail(usuarioResult.Errors.Select(erro => new Error(erro.Description)));
            }

            return Result.Ok(usuario);
        }

        public async Task<Result<Usuario>> LoginAsync(string login, string senha)
        {
            var loginResult = await sign.PasswordSignInAsync(login, senha, false, true);

            var erros = new List<IError>();

            if (loginResult.IsLockedOut)
            {
                erros.Add(new Error("O acesso foi bloqueado"));
            }

            if (loginResult.IsNotAllowed)
            {
                erros.Add(new Error("Login ou senha incorretos"));
            }

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            var usuario = await userManager.FindByNameAsync(login);

            return Result.Ok(usuario); ;
        }

        public async Task<Result<Usuario>> LogoutAsync()
        {
            await sign.SignOutAsync();

            return Result.Ok(); ;
        }
    }
}
