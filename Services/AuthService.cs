using GabiniBackEnd.Models;
using GabiniBackEnd.Repositories;

namespace GabiniBackEnd.Services
{
    public class AuthService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public AuthService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Login(string email, string senha)
        {
            Usuario? usuario = await _usuarioRepository.ObterUsuarioPorEmail(email);
            if (usuario != null && usuario.Senha == senha)
            {
                return true;
            }
            return false;
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await _usuarioRepository.ObterUsuarioPorEmail(email);
        }
    }
}
