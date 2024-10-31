using Microsoft.EntityFrameworkCore;
using ProjetoCarrinhoProdutos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoCarrinhoProdutos.Repositories
{
    public class UsuarioRepository
    {
        private readonly CarrinhoDbContext _context;

        public UsuarioRepository(CarrinhoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorId(string id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task CriarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuario(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
