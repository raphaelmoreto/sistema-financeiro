using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Dtos;

namespace SistemaFinanceiro.Application.Reports.Importar
{
    public class ArquivoTransacaoXlsx : BaseImportarArquivo<TransacaoInputPorArquivoDto>, ICriarDados<TransacaoInputPorArquivoDto>
    {
        public ArquivoTransacaoXlsx(byte[] dados) : base(dados)
        {
        }

        protected override List<TransacaoInputPorArquivoDto> ConverterBytesEmDados()
        {
            throw new NotImplementedException();
        }
    }
}
