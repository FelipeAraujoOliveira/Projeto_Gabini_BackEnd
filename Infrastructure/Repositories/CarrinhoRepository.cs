using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly CarrinhosDbContext _context;

        public CarrinhoRepository(CarrinhosDbContext context)
        {
            _context = context;
        }

        public async Task<Carrinho> SaveCarrinho(Carrinho carrinho)
        {
            _context.Carrinhos.Add(carrinho);
            await _context.SaveChangesAsync();
            return carrinho;
        }

        public async Task<Carrinho> GetCarrinhoById(string id)
        {
            return await _context.Carrinhos
                .Include(c => c.Produtos)
                    .ThenInclude(i => i.Produto)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Carrinho>> GetAllCarrinhos()
        {
            return await _context.Carrinhos
                .Include(c => c.Produtos)
                    .ThenInclude(i => i.Produto)
                .Include(c => c.Usuario)
                .ToListAsync();
        }

        public async Task<bool> DeleteCarrinho(string id)
        {
            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho == null) return false;

            _context.Carrinhos.Remove(carrinho);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
