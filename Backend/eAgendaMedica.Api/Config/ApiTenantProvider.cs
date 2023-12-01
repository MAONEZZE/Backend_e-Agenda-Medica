using eAgendaMedica.Dominio.Compartilhado;
using System.Security.Claims;

namespace eAgendaMedica.Api.Config
{
    public class ApiTenantProvider : ITenantProvider
    {
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
    }
}
