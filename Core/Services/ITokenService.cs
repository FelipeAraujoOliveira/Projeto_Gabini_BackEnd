using Core.Models;

namespace Core.Services
{
    public interface ITokenService
    {

        public string CreateUsuarioToken(Usuario usuario);

    }
}
