using ProjetoCarrinhoProdutos.Models;

namespace ProjetoCarrinhoProdutos.Interfaces
{
    public interface IAuthRepository
    {
        public Task<Usuario> GetUserByEmailAndPassword(string email, string password);
    }
}
