using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.Domain.Dtos;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransacao([FromRoute] int id)
        {
            try
            {
                var result = await transacaoServices.DeleteTransacao(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("busca-por-id")]
        public async Task<IActionResult> GetTransacoesPorId([FromQuery] int id)
        {
            try
            {
                var result = await transacaoServices.BuscarTransacaoPorId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTransacoes()
        {
            try
            {
                var result = await transacaoServices.BuscarTransacoes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
