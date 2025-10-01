using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Application.Reports;
using System.Globalization;

namespace SistemaFinanceiro.Application.Services
{
    public class RelatorioTransacaoService : IRelatorioServices
    {
        private readonly ITransacaoServices transacaoServices;

        public RelatorioTransacaoService(ITransacaoServices transacaoServices)
        {
            this.transacaoServices = transacaoServices;
        }

        public async Task<byte[]> GerarRelatorio(string extensao)
        {
            if (string.IsNullOrWhiteSpace(extensao))
                throw new ArgumentNullException("EXTENSÃO NÃO DECLARADA");

            var transacoes = await transacaoServices.BuscarTransacoes();

            var dados = transacoes.Select(
                t => $"{t.Descricao}; " +
                       $"{t.Categoria}; " +
                       $"{t.Natureza}; " +
                       $"{t.Valor.ToString("F2", CultureInfo.InvariantCulture)}; " +
                       $"{t.Data_Transacao.ToString("dd/MM/yyyy")}"
            ).ToList();

            byte[] bytes = extensao.ToLower() switch
            {
                ".txt" => new RelatorioTransacaoTxt(dados).GerarBytes(),
                ".csv" => new RelatorioTransacaoCsv(dados).GerarBytes(),
                _ => throw new ArgumentException("EXTENSÃO NÃO SUPORTADA")
            };

            return bytes;
        }
    }
}
