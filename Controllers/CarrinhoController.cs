using Microsoft.AspNetCore.Mvc;
using GabiniBackEnd.Models;
using GabiniBackEnd.Services;

namespace GabiniBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly CarrinhoService _carrinhoService;

        public CarrinhoController(CarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrinho>>> GetCarrinhos()
        {
            var carrinhos = await _carrinhoService.ObterTodosCarrinhos();
            return Ok(carrinhos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carrinho>> GetCarrinho(string id)
        {
            try
            {
                var carrinho = await _carrinhoService.ObterCarrinhoPorId(id);
                return Ok(carrinho);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Carrinho>> CreateCarrinho([FromBody] Carrinho carrinho)
        {
            if (carrinho == null || string.IsNullOrWhiteSpace(carrinho.UsuarioId))
            {
                return BadRequest("Dados do carrinho inválidos.");
            }

            await _carrinhoService.CriarCarrinho(carrinho);
            return CreatedAtAction(nameof(GetCarrinho), new { id = carrinho.Id }, carrinho);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCarrinho(string id, [FromBody] Carrinho carrinhoAtualizado)
        {
            if (carrinhoAtualizado == null)
            {
                return BadRequest("Dados do carrinho inválidos.");
            }

            try
            {
                await _carrinhoService.AtualizarCarrinho(id, carrinhoAtualizado);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarrinho(string id)
        {
            try
            {
                await _carrinhoService.DeletarCarrinho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{id}/adicionar")]
        [ProducesResponseType<int>(StatusCodes.Status200OK)]
        public ActionResult AdicionarProduto(string id, [FromBody] Produto produto)
        {
            try
            {
                var carrinho = _carrinhoService.ObterCarrinhoPorId(id).Result;
                _carrinhoService.AdicionarProduto(carrinho, produto);
                return Ok(carrinho);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/remover/{idProduto}")]
        [ProducesResponseType<int>(StatusCodes.Status200OK)]
        public ActionResult RemoverProduto(string id, string idProduto)
        {
            try
            {
                var carrinho = _carrinhoService.ObterCarrinhoPorId(id).Result;
                _carrinhoService.RemoverProduto(carrinho, idProduto);
                return Ok(carrinho);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
