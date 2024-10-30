using ProjetoCarrinhoProdutos.Models;
using ProjetoCarrinhoProdutos.Repositories;
using System.Threading.Tasks;

namespace ProjetoCarrinhoProdutos.Services
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
    }
}
