using EstoqueMaster.Core.Entities;
using EstoqueMaster.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduto(Produto produto)
        {
            var createdProduto = await _produtoRepository.AddAsync(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = createdProduto.Id }, createdProduto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            await _produtoRepository.UpdateAsync(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            await _produtoRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("estoque-baixo")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosComEstoqueBaixo()
        {
            var produtos = await _produtoRepository.GetProdutosComEstoqueBaixoAsync();
            return Ok(produtos);
        }

        [HttpGet("categoria/{categoria}")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosPorCategoria(string categoria)
        {
            var produtos = await _produtoRepository.GetByCategoriaAsync(categoria);
            return Ok(produtos);
        }
    }
}