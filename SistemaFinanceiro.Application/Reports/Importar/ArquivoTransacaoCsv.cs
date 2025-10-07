using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Dtos;

namespace SistemaFinanceiro.Application.Reports.Importar
{
    public class ArquivoTransacaoCsv : BaseImportarArquivo<TransacaoInputPorArquivoDto>, ICriarDados<TransacaoInputPorArquivoDto>
    {
        public ArquivoTransacaoCsv(byte[] dados) : base(dados) { }

        protected override List<TransacaoInputPorArquivoDto> ConverterBytesEmDados()
        {
            throw new NotImplementedException();
        }
    }
}
