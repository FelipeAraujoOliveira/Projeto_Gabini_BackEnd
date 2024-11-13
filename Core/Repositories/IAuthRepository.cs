using Core.Models;

namespace Core.Repositories
{
    public interface IAuthRepository
    {

        public Task<Usuario?> GetUsuarioByEmailAndPassword(string email, string senha);

    }
}
