using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDTO> GetUsuarioById(string usuarioId)
        {
            var usuario = await _usuarioRepository.GetUsuario(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            return new UsuarioDTO
            {
                Id = usuario.Id,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                NomeDeUsuario = usuario.NomeDeUsuario,
                Endereco = usuario.Enderecos.Count > 0 ? usuario.Enderecos.First().Rua : null,
                Cidade = usuario.Enderecos.Count > 0 ? usuario.Enderecos.First().Cidade : null,
                Estado = usuario.Enderecos.Count > 0 ? usuario.Enderecos.First().Estado : null,
                Cep = usuario.Enderecos.Count > 0 ? usuario.Enderecos.First().Cep : null,
                Url_foto_perfil = usuario.Url_foto_perfil,
            };
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllUsuarios();
            return usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                NomeDeUsuario = usuario.NomeDeUsuario,
                Url_foto_perfil = usuario.Url_foto_perfil
            });
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            return await _usuarioRepository.CreateUsuario(usuario);
        }

        public async Task<Usuario> UpdateUsuario(string usuarioId, Usuario usuario)
        {
            return await _usuarioRepository.UpdateUsuario(usuarioId, usuario);
        }

        public async Task<bool> DeleteUsuario(string usuarioId)
        {
            return await _usuarioRepository.DeleteUsuario(usuarioId);
        }

        public async Task<Usuario> GetUsuarioOrThrowException(string usuarioId)
        {
            var usuario = await _usuarioRepository.GetUsuario(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            return usuario;
        }
    }
}
