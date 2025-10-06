using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Dtos;
using System.Text;

namespace SistemaFinanceiro.Application.Reports.Importar
{
    public class ArquivoTransacaoTxt : BaseImportarArquivo<TransacaoInputPorArquivoDto>, ICriarDados<TransacaoInputPorArquivoDto>
    {
        public ArquivoTransacaoTxt(byte[] dados) : base(dados) { }

        protected override List<TransacaoInputPorArquivoDto> ConverterBytesEmDados()
        {
            List<TransacaoInputPorArquivoDto> transacoes = [];

            var dados = Encoding.UTF8.GetString(Dados);
            var context = dados.Split(Environment.NewLine);

            throw new NotImplementedException();
        }
    }
}
