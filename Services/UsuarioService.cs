using GabiniBackEnd.Models;
using GabiniBackEnd.Repositories;

namespace GabiniBackEnd.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await _usuarioRepository.ObterTodosUsuarios();
        }

        public async Task<Usuario> ObterUsuarioPorId(string id)
        {
            return await _usuarioRepository.ObterUsuarioPorId(id);
        }

        public async Task CriarUsuario(Usuario usuario)
        {
            await _usuarioRepository.CriarUsuario(usuario);
        }

        public async Task AtualizarUsuario(string id, Usuario usuarioAtualizado)
        {
            var usuario = await ObterUsuarioPorId(id);
            if (usuario != null)
            {
                usuario.NomeCompleto = usuarioAtualizado.NomeCompleto;
                usuario.Email = usuarioAtualizado.Email;
                usuario.Telefone = usuarioAtualizado.Telefone;
                usuario.NomeDeUsuario = usuarioAtualizado.NomeDeUsuario;
                usuario.Endereco = usuarioAtualizado.Endereco;
                usuario.Cidade = usuarioAtualizado.Cidade;
                usuario.Estado = usuarioAtualizado.Estado;
                usuario.Cep = usuarioAtualizado.Cep;
                usuario.Senha = usuarioAtualizado.Senha;
                usuario.DataNascimento = usuarioAtualizado.DataNascimento;
                usuario.Cpf = usuarioAtualizado.Cpf;
                usuario.Ativo = usuarioAtualizado.Ativo;
                usuario.Url_foto_perfil = usuarioAtualizado.Url_foto_perfil;

                await _usuarioRepository.AtualizarUsuario(usuario);
            }
        }

        public async Task DeletarUsuario(string id)
        {
            var usuario = await ObterUsuarioPorId(id);
            if (usuario != null)
            {
                await _usuarioRepository.DeletarUsuario(usuario);
            }
        }
    }
}
