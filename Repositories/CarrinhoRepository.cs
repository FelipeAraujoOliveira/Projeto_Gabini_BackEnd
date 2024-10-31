using Microsoft.EntityFrameworkCore;
using GabiniBackEnd.Models;

namespace GabiniBackEnd.Repositories
{
    public class CarrinhoRepository
    {
        private readonly GabiniBackEndDbContext _context;

        public CarrinhoRepository(GabiniBackEndDbContext context)
        {
            _context = context;
        }

        public async Task<Carrinho?> ObterCarrinhoPorId(string idCarrinho)
        {
            return await _context.Carrinhos.Include(c => c.Produtos).FirstOrDefaultAsync(c => c.Id == idCarrinho);
        }

        public async Task<IEnumerable<Carrinho>> ObterTodos()
        {
            return await _context.Carrinhos.Include(c => c.Produtos).ToListAsync();
        }

        public async Task Adicionar(Carrinho carrinho)
        {
            await _context.Carrinhos.AddAsync(carrinho);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(string idCarrinho, Carrinho carrinhoAtualizado)
        {
            var carrinho = await ObterCarrinhoPorId(idCarrinho);
            if (carrinho == null)
            {
                throw new Exception("Carrinho não encontrado");
            }

            carrinho.UsuarioId = carrinhoAtualizado.UsuarioId;
            carrinho.Produtos = carrinhoAtualizado.Produtos;
            carrinho.DataCompra = carrinhoAtualizado.DataCompra;
            carrinho.PrecoTotal = carrinhoAtualizado.PrecoTotal;

            _context.Carrinhos.Update(carrinho);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(string idCarrinho)
        {
            var carrinho = await ObterCarrinhoPorId(idCarrinho);
            if (carrinho == null)
            {
                throw new Exception("Carrinho não encontrado");
            }

            _context.Carrinhos.Remove(carrinho);
            await _context.SaveChangesAsync();
        }
    }
}
