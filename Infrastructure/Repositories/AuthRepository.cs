using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly CarrinhosDbContext _context;

        public AuthRepository(CarrinhosDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUsuarioByEmailAndPassword(string email, string senha)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(c => c.Email == email && c.Senha == senha);
        }
    }
}
