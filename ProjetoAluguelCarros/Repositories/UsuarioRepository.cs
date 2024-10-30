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

        public async Task<Usuario?> ObterUsuarioPorId(string idUsuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(c => c.Id == idUsuario);
        }

        public async Task<Usuario?> ObterUsuarioPorEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(string idUsuario, Usuario usuarioAtualizado)
        {
            var usuario = await ObterUsuarioPorId(idUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;
            usuario.Ativo = usuarioAtualizado.Ativo;
            usuario.Senha = usuarioAtualizado.Senha;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(string idUsuario)
        {
            var usuario = await ObterUsuarioPorId(idUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
