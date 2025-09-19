using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.Application.Dtos;
using SistemaFinanceiro.Application.Interfaces;

namespace SistemaFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoServices transacaoServices;

        public TransacaoController(ITransacaoServices transacaoServices)
        {
            this.transacaoServices = transacaoServices;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransacao([FromBody] TransacaoInputDto transacaoInputDto)
        {
            try
            {
                var result = await transacaoServices.CriarTransacao(transacaoInputDto);
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
        public async Task<IActionResult> PutTransacao([FromRoute] int id, [FromBody] TransacaoInputDto transacaoInputDto)
        {
            try
            {
                var result = await transacaoServices.AtualizarTransacao(id, transacaoInputDto);
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
