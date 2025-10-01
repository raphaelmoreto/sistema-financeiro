using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Application.Reports;

namespace SistemaFinanceiro.Application.Services
{
    public class GerarRelatorioTransacao : IGerarRelatorio
    {
        private readonly ITransacaoServices transacaoServices;

        public GerarRelatorioTransacao(ITransacaoServices transacaoServices)
        {
            this.transacaoServices = transacaoServices;
        }

        public async Task<byte[]> GerarRelatorio(string extensao)
        {
            if (string.IsNullOrWhiteSpace(extensao))
                throw new ArgumentNullException("EXTENSÃO NÃO DECLARADA");

            var transacoes = await transacaoServices.BuscarTransacoes();
            var data = transacoes.Select(t => t.ToString()).ToList();

            var bytes = extensao.ToLower() switch
            {
                ".txt" => new RelatorioTxt(data).GerarBytes(),
                _ => throw new ArgumentException("EXTENSÃO NÃO SUPORTADA")
            };

            return bytes;
        }
    }
}
