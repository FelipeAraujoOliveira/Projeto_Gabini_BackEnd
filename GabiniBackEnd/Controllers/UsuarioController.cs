using Microsoft.AspNetCore.Mvc;
using ProjetoCarrinhoProdutos.Models;
using ProjetoCarrinhoProdutos.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoCarrinhoProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.ObterTodosUsuarios();
            return Ok(usuarios);
        }

        // GET: api/usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string id)
        {
            try
            {
                var usuario = await _usuarioService.ObterUsuarioPorId(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrWhiteSpace(usuario.Nome) || string.IsNullOrWhiteSpace(usuario.Senha))
            {
                return BadRequest("Dados inválidos.");
            }

            await _usuarioService.CriarUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/usuario/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuario(string id, [FromBody] Usuario usuarioAtualizado)
        {
            if (usuarioAtualizado == null || string.IsNullOrWhiteSpace(usuarioAtualizado.Nome) || string.IsNullOrWhiteSpace(usuarioAtualizado.Senha))
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                await _usuarioService.AtualizarUsuario(id, usuarioAtualizado);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/usuario/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(string id)
        {
            try
            {
                await _usuarioService.DeletarUsuario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
