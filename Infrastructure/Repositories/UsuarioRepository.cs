using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CarrinhosDbContext _context;

        public UsuarioRepository(CarrinhosDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUsuario(string usuarioId)
        {
            return await _context.Usuarios.Include(u => u.Enderecos).FirstOrDefaultAsync(c => c.Id == usuarioId);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios.Include(u => u.Enderecos).ToListAsync();
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateUsuario(string usuarioId, Usuario usuario)
        {
            var existingUsuario = await GetUsuario(usuarioId);
            if (existingUsuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            // Atualizar propriedades
            existingUsuario.NomeCompleto = usuario.NomeCompleto;
            existingUsuario.Email = usuario.Email;
            existingUsuario.Telefone = usuario.Telefone;
            existingUsuario.NomeDeUsuario = usuario.NomeDeUsuario;
            existingUsuario.Senha = usuario.Senha; // Considere a segurança ao atualizar senhas
            existingUsuario.DataNascimento = usuario.DataNascimento;
            existingUsuario.Cpf = usuario.Cpf;
            existingUsuario.Ativo = usuario.Ativo;
            existingUsuario.Url_foto_perfil = usuario.Url_foto_perfil;

            // Atualizando Endereços
            existingUsuario.Enderecos = usuario.Enderecos; // Considera a substituição total dos endereços

            await _context.SaveChangesAsync();
            return existingUsuario;
        }

        public async Task<bool> DeleteUsuario(string usuarioId)
        {
            var usuario = await GetUsuario(usuarioId);
            if (usuario == null)
            {
                return false; // Usuário não encontrado
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
