using Microsoft.EntityFrameworkCore;
using ProjetoCarrinhoProdutos.Interfaces;
using ProjetoCarrinhoProdutos.Models;

namespace ProjetoCarrinhoProdutos.Repositories
{
    public class AuthRepository : IAuthRepository
    {       
        private readonly CarrinhoDbContext _context;
        public AuthRepository(CarrinhoDbContext context) 
        { 
            _context = context;
        }
        public async Task<Usuario?> GetUserByEmailAndPassword(string email, string password)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == email && usuario.Senha == password)
        }
    }
}
