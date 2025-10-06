using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.API.Helpers;
using SistemaFinanceiro.Application.Interfaces;

namespace SistemaFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioTransacaoController : ControllerBase
    {
        private readonly IRelatorioServices relatorioServices;

        public RelatorioTransacaoController(IRelatorioServices relatorioServices)
        {
            this.relatorioServices = relatorioServices;
        }

        [HttpPost("download")]
        public async Task<IActionResult> DownloadRelatorioTransacao([FromBody] string extensao)
        {
            //"File(...)" É UM "helper" DO ASP.NET Core MVC Controller. ELE SERVE PARA RETORNAR UM ARQUIVO COMO RESPOSTA HTTP PARA O CLIENTE (NAVEGADOR, POSTMAN, ETC.)

            //"Content - Type(OU TIPO MIME)" É UMA ETIQUETA USADA PARA DIZER QUE TIPO DE CONTEÚDO UM ARQUIVO OU DADO É PARA QUE POSSA SER PROCESSADO OU EXIBIDO CORRETAMENTE. EXEMPLO, E-MAILS

            //"application/octet-stream" É UM "MIME type" QUE SIGNIFICA "FLUXO BINÁRIO GENÉRICO". É USADO QUANDO O TIPO DO ARQUIVO NÃO É ESPECÍFICO (COMO PDF, XLSX, ETC.). ISSO FAZ O NAVEGADOR BAIXAR O ARQUIVO EM VEZ DE TENTAR ABRIR DIRETAMENTE
            try
            {
                var result = await relatorioServices.GerarRelatorio(extensao);
                return File(result, MimeTypeHelper.GetMimeType(extensao), $"relatorio-de-transacaoes{extensao}");
                //"return File(bytes, "application/pdf", "relatorio.pdf")" ASSIM O NAVEGADOR JÁ RECONHECE QUE É PDF E O ABRE DIRETAMENTE
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadArquivoTransacao(IFormFile arquivo)
        {
            using var memoryStream = new MemoryStream();
            await arquivo.CopyToAsync(memoryStream);
            try
            {
                var result = await relatorioServices.ImportarArquivo(Path.GetExtension(arquivo.FileName), memoryStream.ToArray());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
