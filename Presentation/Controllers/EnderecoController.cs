using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoDTO>> GetEndereco(string id)
        {
            try
            {
                var endereco = await _enderecoService.GetEnderecoById(id);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> GetAllEnderecos()
        {
            var enderecos = await _enderecoService.GetAllEnderecos();
            return Ok(enderecos);
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoDTO>> CreateEndereco([FromBody] Endereco endereco)
        {
            var createdEndereco = await _enderecoService.CreateEndereco(endereco);
            return CreatedAtAction(nameof(GetEndereco), new { id = createdEndereco.Id }, createdEndereco);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EnderecoDTO>> UpdateEndereco(string id, [FromBody] Endereco endereco)
        {
            try
            {
                var updatedEndereco = await _enderecoService.UpdateEndereco(id, endereco);
                return Ok(updatedEndereco);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(string id)
        {
            var result = await _enderecoService.DeleteEndereco(id);
            if (!result)
            {
                return NotFound("Endereço não encontrado");
            }
            return NoContent();
        }
    }
}
