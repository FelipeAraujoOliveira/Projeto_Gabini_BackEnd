using Application.Services;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoController(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        // POST: api/Carrinho
        [HttpPost]
        public async Task<IActionResult> CreateCarrinho([FromBody] CarrinhoCreateDTO carrinhoDto)
        {
            var carrinho = await _carrinhoService.SaveCarrinho(carrinhoDto.UsuarioId, carrinhoDto.ProdutosDTO);

            if (carrinho == null)
                return BadRequest("Erro ao criar carrinho.");

            return CreatedAtAction(nameof(GetCarrinhoById), new { id = carrinho.Id }, carrinho);
        }

        // GET: api/Carrinho/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrinhoById(string id)
        {
            var carrinho = await _carrinhoService.GetCarrinhoById(id);

            if (carrinho == null)
                return NotFound("Carrinho não encontrado.");

            return Ok(carrinho);
        }

        // GET: api/Carrinho
        [HttpGet]
        public async Task<IActionResult> GetAllCarrinhos()
        {
            var carrinhos = await _carrinhoService.GetAllCarrinhos();
            return Ok(carrinhos);
        }

        // PUT: api/Carrinho/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarrinho(string id, [FromBody] CarrinhoUpdateDTO carrinhoDto)
        {
            var updatedCarrinho = await _carrinhoService.UpdateCarrinho(id, carrinhoDto);

            if (updatedCarrinho == null)
                return NotFound("Carrinho não encontrado.");

            return Ok(updatedCarrinho);
        }

        // DELETE: api/Carrinho/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrinho(string id)
        {
            var deleted = await _carrinhoService.DeleteCarrinho(id);

            if (!deleted)
                return NotFound("Carrinho não encontrado.");

            return NoContent();
        }
    }
}
