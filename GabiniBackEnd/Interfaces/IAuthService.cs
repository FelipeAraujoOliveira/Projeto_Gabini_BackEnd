using System.Security.Claims;

namespace ProjetoCarrinhoProdutos.Interfaces
{
    public interface IAuthService
    {
        public Task<string> Login(string email, string password);

        public string? GetAuthenticatedUserId(ClaimsPrincipal User);
    }
}
