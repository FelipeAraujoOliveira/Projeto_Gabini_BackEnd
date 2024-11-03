using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarioById(string id)
        {
            var usuarioDTO = await _usuarioService.GetUsuarioById(id);
            if (usuarioDTO == null) return NotFound();
            return Ok(usuarioDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAllUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] Usuario usuario)
        {
            var createdUsuario = await _usuarioService.CreateUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = createdUsuario.Id }, createdUsuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(string id, [FromBody] Usuario usuario)
        {
            var updatedUsuario = await _usuarioService.UpdateUsuario(id, usuario);
            if (updatedUsuario == null) return NotFound();
            return Ok(updatedUsuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            var deleted = await _usuarioService.DeleteUsuario(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
