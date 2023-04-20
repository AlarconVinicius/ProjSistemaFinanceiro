using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ProjSistemaFinanceiro.Identity.Servicos
{
    public static class AutenticacaoHelper
    {
        public static async Task<string> ObterUsuarioId(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext.User;

            if (user?.Identity?.IsAuthenticated == true)
            {
                return user.FindFirst(ClaimTypes.NameIdentifier).Value;
            }

            return null;
        }
    }

}
