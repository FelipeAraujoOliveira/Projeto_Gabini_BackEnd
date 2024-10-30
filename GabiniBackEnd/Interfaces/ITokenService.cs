using ProjetoCarrinhoProdutos.Models;

namespace ProjetoCarrinhoProdutos.Interfaces
{
    public interface ITokenService
    {
        public string CreateCustomerToken(Usuario usuario);

    }
}
