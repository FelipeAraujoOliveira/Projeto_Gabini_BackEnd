using Core.Models;
using Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> GetUsuarioById(string usuarioId);
        Task<IEnumerable<UsuarioDTO>> GetAllUsuarios();
        Task<Usuario> CreateUsuario(UsuarioDTO usuarioDTO, EnderecoDTO enderecoDTO);

        Task<Usuario> UpdateUsuario(string usuarioId, Usuario usuario);
        Task<bool> DeleteUsuario(string usuarioId);
        Task<Usuario> GetUsuarioOrThrowException(string usuarioId);
    }
}
