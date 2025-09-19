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
    }
}
