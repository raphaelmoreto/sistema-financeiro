using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Application.Reports;

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
            var dados = transacoes.Select(t => t.ToString()).ToList();

            byte[] bytes = extensao.ToLower() switch
            {
                ".txt" => new RelatorioTransacaoTxt(dados).GerarBytes(),
                _ => throw new ArgumentException("EXTENSÃO NÃO SUPORTADA")
            };

            return bytes;
        }
    }
}
