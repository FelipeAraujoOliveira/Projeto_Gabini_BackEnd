using Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.Services
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetProdutos(List<string> produtosIds);
        Task Add(Produto produto);
        Task<Produto> GetProdutoById(string id);
        Task<List<Produto>> GetAllProdutos();

    }
}
