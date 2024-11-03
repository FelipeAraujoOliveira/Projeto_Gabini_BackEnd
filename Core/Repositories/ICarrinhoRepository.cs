using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho> SaveCarrinho(Carrinho carrinho);
        Task<Carrinho> GetCarrinhoById(string id);
        Task<IEnumerable<Carrinho>> GetAllCarrinhos();
        Task<bool> DeleteCarrinho(string id);
    }
}
