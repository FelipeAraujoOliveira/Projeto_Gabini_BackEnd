using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Application.Services;
using Core.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutos([FromQuery] List<string> produtosIds)
        {
            if (produtosIds == null || !produtosIds.Any())
            {
                var lista_produtos = await _produtoService.GetAllProdutos();
                return Ok(lista_produtos);
            }

            var produtos = await _produtoService.GetProdutos(produtosIds);
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto não pode ser nulo.");
            }

            await _produtoService.Add(produto);
            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id }, produto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById(string id)
        {
            var produto = await _produtoService.GetProdutoById(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }
    }
}
