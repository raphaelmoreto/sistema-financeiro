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

            //O "ToList()" PRESERVA O TIPO QUE JÁ EXISTE DENTRO DO "IEnumerable<T>". NO CASO ATUAL, PRESERVA UM "IEnumerable<TransacaoOutputDto>"
            var transacoes = (await transacaoServices.BuscarTransacoes()).ToList();

            byte[] bytes = extensao.ToLower() switch
            {
                ".txt" => new RelatorioTransacaoTxt(transacoes).GerarBytes(),
                ".csv" => new RelatorioTransacaoCsv(transacoes).GerarBytes(),
                ".xlsx" => new RelatorioTransacaoXlsx(transacoes).GerarBytes(),
                _ => throw new ArgumentException("EXTENSÃO NÃO SUPORTADA")
            };

            return bytes;
        }
    }
}
