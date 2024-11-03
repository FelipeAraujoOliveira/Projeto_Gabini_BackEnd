using Core.Models;
using Core.Repositories;
using Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<Produto>> GetProdutos(List<string> produtosIds)
        {
            return await _produtoRepository.GetProdutos(produtosIds);
        }

        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _produtoRepository.GetAllProdutos();
        }

        public async Task Add(Produto produto)
        {
            await _produtoRepository.Add(produto);
        }

        public async Task<Produto> GetProdutoById(string id)
        {
            return await _produtoRepository.GetProdutoById(id);
        }
    }
}
