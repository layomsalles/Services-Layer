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

                var produtoRepository = new ProdutoRepository();
                produtoRepository.AddProdutc(produto);

                return StatusCode(201, new { message = "Product registered successfully" });
            } catch (Exception error)
            {
                return StatusCode(500, new { message = $"Error registering product {error.Message}" });
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Produto Get controller is working");
        }

        //[HttpGet]
        //public IActionResult GetById() {
        //    return Ok("Produto GetById controller is working");
        //}

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Produto Put controller is working");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Produto Delete controller is working");
        }
    }
}
