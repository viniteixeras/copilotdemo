using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using copilotdemo.Models;
using copilotdemo.Repositories;
using System.Collections.Generic;
using System;

namespace copilotdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os produtos cadastrados
        /// </summary>
        /// <returns>
        /// 200 OK com a lista de produtos quando existem produtos cadastrados
        /// 404 NotFound quando não existem produtos cadastrados
        /// 500 Internal Server Error em caso de erro no servidor
        /// </returns>
        /// <response code="200">Retorna a lista de produtos</response>
        /// <response code="404">Quando não existem produtos cadastrados</response>
        /// <response code="500">Quando ocorre um erro interno no servidor</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            try
            {
                var produtos = _repository.GetAll();
                if (produtos == null || !produtos.Any())
                    return NotFound("Nenhum produto encontrado.");
                    
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET: api/produtos/5
        [HttpGet("{id}")]
        public ActionResult<Produto> GetProduto(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("ID inválido.");

                var produto = _repository.GetById(id);
                if (produto == null)
                    return NotFound($"Produto com ID {id} não encontrado.");

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // POST: api/produtos
        [HttpPost]
        public ActionResult<Produto> PostProduto(Produto produto)
        {
            try
            {
                if (produto == null)
                    return BadRequest("Dados do produto inválidos.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Add(produto);
                return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // PUT: api/produtos/5
        [HttpPut("{id}")]
        public IActionResult PutProduto(int id, Produto produto)
        {
            try
            {
                if (produto == null || id != produto.Id)
                    return BadRequest("Dados do produto inválidos.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingProduto = _repository.GetById(id);
                if (existingProduto == null)
                    return NotFound($"Produto com ID {id} não encontrado.");

                _repository.Update(produto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // DELETE: api/produtos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("ID inválido.");

                var produto = _repository.GetById(id);
                if (produto == null)
                    return NotFound($"Produto com ID {id} não encontrado.");

                _repository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
