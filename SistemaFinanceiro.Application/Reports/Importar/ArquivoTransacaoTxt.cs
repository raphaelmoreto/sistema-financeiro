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
            List<TransacaoInputPorArquivoDto> lstTransacoes = [];

            var dados = Encoding.UTF8.GetString(Dados);
            var transacoes = dados.Split(Environment.NewLine);

            for (int i = 0; i < Dados.Length; i++)
            {
                var transacao = transacoes[i].Split('\t');
            }

            throw new NotImplementedException();
        }
    }
}
