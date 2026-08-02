using Data_Layer.Repositories;
using Domain_Layer.Entities;
using Domain_Layer.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services_Layer.Dtos;

namespace Services_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutosController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequest request)
        {
            try
            {
                var produto = new Produto()
                {
                    Nome = request.nome,
                    Preco = request.preco,
                    Quantidade = request.quantidade
                };

                var validator = new ProdutoValidator();
                var result = validator.Validate(produto);

                if(!result.IsValid)
                {
                    return StatusCode(400, result.Errors.Select(error => error.ErrorMessage));
                }

                _produtoRepository.AddProdutc(produto);

                return StatusCode(201, new { message = "Product registered successfully" }, produto);
            } catch (Exception error)
            {
                return StatusCode(500, new { message = $"Error registering product {error.Message}" });
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _produtoRepository.GetProduct();
            return Ok(produtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var produto = _produtoRepository.GetById(id);

            if(produto is null)
            {
                return NotFound(new { message = "Product not found" });
            }
            return Ok(produto);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody] ProdutoRequest request)
        {
            try
            {
                var product = _produtoRepository.GetById(id);

                if(product is null)
                {
                    return NotFound(new { message = "Product not found" });
                }

                product.Nome = request.nome;
                product.Preco = request.preco;
                product.Quantidade = request.quantidade;

                var validator = new ProdutoValidator();
                var result = validator.Validate(product);

                if(!result.IsValid)
                {
                    return StatusCode(400, result.Errors.Select(error => error.ErrorMessage));
                }

                _produtoRepository.UpdateProduct(product);

                return Ok(new { message = "Product update successfully" }, product);
            } catch (Exception error)
            {
                return StatusCode(500, new { message = $"Error updating product {error.Message}" });
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var productId = _produtoRepository.GetById(id);

            if(productId is null)
            {
                return NotFound(new { message = "Product not found" });
            }

            _produtoRepository.DeleteProduct(productId);
            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
