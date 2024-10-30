using Microsoft.EntityFrameworkCore;
using ProjetoCarrinhoProdutos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoCarrinhoProdutos.Repositories
{
    public class ProdutoRepository
    {
        private readonly CarrinhoDbContext _context;

        public ProdutoRepository(CarrinhoDbContext context)
        {
            _context = context;
        }

        public async Task<Produto?> ObterProdutoPorId(string idProduto)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == idProduto);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task Adicionar(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(string idProduto, Produto produtoAtualizado)
        {
            var produto = await ObterProdutoPorId(idProduto);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            produto.Quantidade = produtoAtualizado.Quantidade;
            produto.Image_url = produtoAtualizado.Image_url;

            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(string idProduto)
        {
            var produto = await ObterProdutoPorId(idProduto);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
