using Microsoft.AspNetCore.Mvc;
using GabiniBackEnd.Models;
using GabiniBackEnd.Services;

namespace GabiniBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _produtoService.ObterTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(string id)
        {
            try
            {
                var produto = await _produtoService.ObterProdutoPorId(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduto([FromBody] Produto produto)
        {
            if (produto == null || string.IsNullOrWhiteSpace(produto.Nome) || produto.Preco <= 0 || produto.Quantidade < 0)
            {
                return BadRequest("Dados inválidos.");
            }

            await _produtoService.CriarProduto(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduto(string id, [FromBody] Produto produtoAtualizado)
        {
            if (produtoAtualizado == null || string.IsNullOrWhiteSpace(produtoAtualizado.Nome) || produtoAtualizado.Preco <= 0 || produtoAtualizado.Quantidade < 0)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                await _produtoService.AtualizarProduto(id, produtoAtualizado);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto(string id)
        {
            try
            {
                await _produtoService.DeletarProduto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
