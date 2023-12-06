using eAgendaMedica.Dominio.Compartilhado;
using System.Security.Claims;

namespace eAgendaMedica.Api.Config
{
    public class ApiTenantProvider : ITenantProvider
    {
        #region Para que serve o Tenant Provider?
        /*
         * Tenant provider significa provedor de inquilinos, ou seja, o tenant provider serve para 
         * separar as informações de cada "inquilino"/usuario que irá acessar a aplicação.
         * 
         * Esse código serve para pegar as informações do usuario que está fazendo o request na API
         * e posteriormente, no dbContext, o sistema retornará com os dados relacionados a esse cliente.
         */
        #endregion

        private readonly IHttpContextAccessor ctx;
        public ApiTenantProvider(IHttpContextAccessor ctx)
        {
            this.ctx = ctx;
        }

        public Guid Usuario_id
        {
            get 
            {
                var claim_id = ctx.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

                if (claim_id == null)
                {
                    return Guid.Empty;
                }

                return Guid.Parse(claim_id.Value);
            }
        }

        #region Explicação do código (Pontos importantes)
        /*
         * O HttpContext obtém o contexto HTTP atual da solicitação.
         * 
         * O User geralmente contém as informações do usuário associadas à solicitação.
         * 
         * FindFirst(ClaimTypes.NameIdentifier) procura pela claim que tem o identificador do nome, 
         * onde é armazenado o id do usuario.
         */
        #endregion
    }
}
