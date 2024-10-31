using Microsoft.AspNetCore.Mvc;
using GabiniBackEnd.Models;
using GabiniBackEnd.Services;

namespace GabiniBackEnd.Controllers
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
            var usuario = await _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");
            return Ok(usuario);
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrWhiteSpace(usuario.NomeCompleto) || string.IsNullOrWhiteSpace(usuario.Senha))
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
            if (usuarioAtualizado == null || string.IsNullOrWhiteSpace(usuarioAtualizado.NomeCompleto) || string.IsNullOrWhiteSpace(usuarioAtualizado.Senha))
            {
                return BadRequest("Dados inválidos.");
            }

            var usuarioExistente = await _usuarioService.ObterUsuarioPorId(id);
            if (usuarioExistente == null)
                return NotFound("Usuário não encontrado.");

            await _usuarioService.AtualizarUsuario(id, usuarioAtualizado);
            return NoContent();
        }

        // DELETE: api/usuario/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(string id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            await _usuarioService.DeletarUsuario(id);
            return NoContent();
        }
    }
}
