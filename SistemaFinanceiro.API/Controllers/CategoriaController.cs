using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.Application.Dtos;
using SistemaFinanceiro.Application.Interfaces;

namespace SistemaFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServices categoriaServices;

        public CategoriaController(ICategoriaServices categoriaServices)
        {
            this.categoriaServices = categoriaServices;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria([FromRoute] int id)
        {
            try
            {
                var result = await categoriaServices.DeletarCategoria(id);
                return Ok(result);
            }
            catch (AggregateException aggEx)
            {
                var mensagens = aggEx.InnerExceptions.Select(ex => ex.Message);
                return BadRequest(new { Erro = mensagens });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("busca-por-id")]
        public async Task<IActionResult> GetCategoriaPorId([FromQuery] int id)
        {
            try
            {
                var result = await categoriaServices.BuscarCategoriaPorId(id);
                return Ok(result);
            }
            catch (AggregateException aggEx)
            {
                var mensagens = aggEx.InnerExceptions.Select(ex => ex.Message);
                return BadRequest(new { erro = mensagens });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Getcategorias()
        {
            try
            {
                var result = await categoriaServices.BuscarCategorias();
                return Ok(result);
            }
            catch (AggregateException aggEx)
            {
                var mensagens = aggEx.InnerExceptions.Select(ex => ex.Message);
                return BadRequest(new { Erro = mensagens });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoria(CategoriaInputDto categoriaInputDto)
        {
            try
            {
                var result = await categoriaServices.CriarCategoria(categoriaInputDto);
                return Ok(result);
            }
            catch (AggregateException aggEx)
            {
                var mensagens = aggEx.InnerExceptions.Select(ex => ex.Message);
                return BadRequest(new { erro = mensagens });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria([FromRoute] int id, [FromBody] CategoriaInputDto categoriaInputDto)
        {
            try
            {
                var result = await categoriaServices.AtualizarCategoria(id, categoriaInputDto);
                return Ok(result);
            }
            catch (AggregateException aggEx)
            {
                var mensagens = aggEx.InnerExceptions.Select(ex => ex.Message);
                return BadRequest(new { Erro = mensagens });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
