using Core.Models;
using Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly GabiniDbContext _context;

        public ProdutoRepository(GabiniDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> GetProdutos(List<string> produtosIds)
        {
            return await _context.Produtos
                .Where(p => produtosIds.Contains(p.Id))
                .ToListAsync();
        }


        public async Task Add(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task Delete(string id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Produto> GetProdutoById(string id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

    }
}
