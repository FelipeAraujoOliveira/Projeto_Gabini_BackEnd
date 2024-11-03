using Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetProdutos(List<string> produtosIds);
        Task Add(Produto produto);
        Task<Produto> Update(Produto produto);
        Task Delete(string id);
        Task<Produto> GetProdutoById(string id);
        Task<List<Produto>> GetAllProdutos();

    }
}
