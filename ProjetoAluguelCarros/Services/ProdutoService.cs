using ProjetoCarrinhoProdutos.Models;
using ProjetoCarrinhoProdutos.Repositories;

namespace ProjetoCarrinhoProdutos.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> ObterProdutoPorId(string idProduto)
        {
            Produto? produto = await _produtoRepository.ObterProdutoPorId(idProduto);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }
            return produto;
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
            return await _produtoRepository.ObterTodos();
        }

        public async Task CriarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(produto.Nome) || produto.Preco <= 0 || produto.Quantidade < 0)
            {
                throw new ArgumentException("Dados do produto inválidos.");
            }

            await _produtoRepository.Adicionar(produto);
        }

        public async Task AtualizarProduto(string idProduto, Produto produtoAtualizado)
        {
            if (produtoAtualizado == null)
            {
                throw new ArgumentNullException(nameof(produtoAtualizado), "Produto atualizado não pode ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(produtoAtualizado.Nome) || produtoAtualizado.Preco <= 0 || produtoAtualizado.Quantidade < 0)
            {
                throw new ArgumentException("Dados do produto inválidos.");
            }

            await _produtoRepository.Atualizar(idProduto, produtoAtualizado);
        }

        public async Task DeletarProduto(string idProduto)
        {
            await _produtoRepository.Deletar(idProduto);
        }
    }
}
