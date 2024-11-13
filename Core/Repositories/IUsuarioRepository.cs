using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetUsuario(string usuarioId);
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(string usuarioId, Usuario usuario);
        Task<bool> DeleteUsuario(string usuarioId);
    }
}
