using ProjetoCarrinhoProdutos.Models;
using ProjetoCarrinhoProdutos.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoCarrinhoProdutos.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> ObterUsuarioPorId(string idUsuario)
        {
            Usuario? usuario = await _usuarioRepository.ObterUsuarioPorId(idUsuario);
            if (usuario == null || !usuario.Ativo)
            {
                throw new Exception("Usuário não encontrado");
            }
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await _usuarioRepository.ObterTodos();
        }

        public async Task CriarUsuario(Usuario usuario)
        {
            await _usuarioRepository.Adicionar(usuario);
        }

        public async Task AtualizarUsuario(string idUsuario, Usuario usuarioAtualizado)
        {
            await _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);
        }

        public async Task DeletarUsuario(string idUsuario)
        {
            await _usuarioRepository.Deletar(idUsuario);
        }
    }
}
