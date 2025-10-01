using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.API.Helpers;
using SistemaFinanceiro.Application.Interfaces;

namespace SistemaFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioTransacaoController : ControllerBase
    {
        private readonly IGerarRelatorio gerarRelatorio;

        public RelatorioTransacaoController(IGerarRelatorio gerarRelatorio)
        {
            this.gerarRelatorio = gerarRelatorio;
        }

        [HttpPost("download")]
        public async Task<IActionResult> DownloadRelatorio([FromBody] string extensao)
        {
            //"File(...)" É UM "helper" DO ASP.NET Core MVC Controller. ELE SERVE PARA RETORNAR UM ARQUIVO COMO RESPOSTA HTTP PARA O CLIENTE (NAVEGADOR, POSTMAN, ETC.)

            //"Content - Type(OU TIPO MIME)" É UMA ETIQUETA USADA PARA DIZER QUE TIPO DE CONTEÚDO UM ARQUIVO OU DADO É PARA QUE POSSA SER PROCESSADO OU EXIBIDO CORRETAMENTE. EXEMPLO, E-MAILS

            //"application/octet-stream" É UM "MIME type" QUE SIGNIFICA "FLUXO BINÁRIO GENÉRICO". É USADO QUANDO O TIPO DO ARQUIVO NÃO É ESPECÍFICO (COMO PDF, XLSX, ETC.). ISSO FAZ O NAVEGADOR BAIXAR O ARQUIVO EM VEZ DE TENTAR ABRIR DIRETAMENTE
            try
            {
                var result = await gerarRelatorio.GerarRelatorio(extensao);
                return File(result, MimeTypeHelper.GetMimeType(extensao), $"relatorio-de-transacao{extensao}");
                //"return File(bytes, "application/pdf", "relatorio.pdf")" ASSIM O NAVEGADOR JÁ RECONHECE QUE É PDF E O ABRE DIRETAMENTE
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
