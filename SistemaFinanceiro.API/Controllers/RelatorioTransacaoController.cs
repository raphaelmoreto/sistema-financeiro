using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioTransacaoController : ControllerBase
    {
        [HttpGet("download")]
        public IActionResult DownloadRelatorio()
        {
            //"File(...)" É UM "helper" DO ASP.NET Core MVC Controller. ELE SERVE PARA RETORNAR UM ARQUIVO COMO RESPOSTA HTTP PARA O CLIENTE (NAVEGADOR, POSTMAN, ETC.)

            //"Content - Type(ou tipo MIME)" É UM IDENTIFICADO DE DUAS PARTES QUE INFORMA O FORMATO DE UM ARQUIVO OU CONTEÚDO EM SISTEMAS DE INTERNET, COMO E-MAIL E WEB, PARA QUE POSSA SER PROCESSADO OU EXIBIDO CORRETAMENTE

            //"application/octet-stream" É UM "MIME type" QUE SIGNIFICA "FLUXO BINÁRIO GENÉRICO". É USADO QUANDO O TIPO DO ARQUIVO NÃO É ESPECÍFICO (COMO PDF, XLSX, ETC.). ISSO FAZ O NAVEGADOR BAIXAR O ARQUIVO EM VEZ DE TENTAR ABRIR DIRETAMENTE
            try
            {
                var result = "";
                return File(result, "application/octet-stream", "relatorio-de-transacao");
                //"return File(bytes, "application/pdf", "relatorio.pdf")" ASSIM O NAVEGADOR JÁ RECONHECE QUE É PDF E O ABRE DIRETAMENTE
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
