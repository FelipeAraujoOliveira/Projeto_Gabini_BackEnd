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
                
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                NomeDeUsuario = usuario.NomeDeUsuario,
                //Endereco = usuario.Enderecos.Count > 0 ? new EnderecoDTO
                //{
                    
                //    Rua = usuario.Enderecos.First().Rua,
                //    Numero = usuario.Enderecos.First().Numero,
                //    Cidade = usuario.Enderecos.First().Cidade,
                //    Estado = usuario.Enderecos.First().Estado,
                //    Cep = usuario.Enderecos.First().Cep
                //} : null,
                Url_foto_perfil = usuario.Url_foto_perfil,
            };
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllUsuarios();
            return usuarios.Select(usuario => new UsuarioDTO
            {
                
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                NomeDeUsuario = usuario.NomeDeUsuario,
                Url_foto_perfil = usuario.Url_foto_perfil,
                //Endereco = usuario.Enderecos.Count > 0 ? new EnderecoDTO
                //{
                    
                //    Rua = usuario.Enderecos.First().Rua,
                //    Numero = usuario.Enderecos.First().Numero,
                //    Cidade = usuario.Enderecos.First().Cidade,
                //    Estado = usuario.Enderecos.First().Estado,
                //    Cep = usuario.Enderecos.First().Cep
                //} : null,
            });
        }

        public async Task<Usuario> CreateUsuario(UsuarioDTO usuarioDTO, EnderecoDTO enderecoDTO)
        {
            if (usuarioDTO == null || enderecoDTO == null)
            {
                throw new Exception("Os dados do usuário e do endereço são necessários.");
            }

            var usuario = new Usuario
            {
                Id = Guid.NewGuid().ToString(),
                NomeCompleto = usuarioDTO.NomeCompleto,
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha,
                Telefone = usuarioDTO.Telefone,
                NomeDeUsuario = usuarioDTO.NomeDeUsuario,
                Url_foto_perfil = usuarioDTO.Url_foto_perfil,
                Cpf = usuarioDTO.Cpf,
                Ativo = true
            };

            var endereco = new Endereco
            {
                Id = Guid.NewGuid().ToString(),
                Rua = enderecoDTO.Rua,
                Numero = enderecoDTO.Numero,
                Cidade = enderecoDTO.Cidade,
                Estado = enderecoDTO.Estado,
                Cep = enderecoDTO.Cep,
                Complemento = enderecoDTO.Complemento,
                UsuarioId = usuario.Id
            };

            usuario.Enderecos = new List<Endereco> { endereco };

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
