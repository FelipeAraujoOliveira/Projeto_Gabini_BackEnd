using Core.Models;
using Core.Repositories;
using Core.Services;
using System.Security.Claims;

namespace Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public string? GetAuthenticatedUserId(ClaimsPrincipal User)
        {
            return User.FindFirst("id")?.Value;
        }

        public async Task<string> SignIn(string email, string senha)
        {
            Usuario? usuario = await _authRepository.GetUsuarioByEmailAndPassword(email, senha);
            if (usuario == null)
            {
                throw new UnauthorizedAccessException("Usuário e/ou senha inválidos");
            }

            string token = _tokenService.CreateUsuarioToken(usuario);

            return token;
        }

    }
}
