using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Dtos;

namespace SistemaFinanceiro.Application.Services
{
    public class RelatorioTransacaoService : IRelatorioServices
    {
        private readonly ITransacaoServices transacaoServices;
        private readonly IFabricaRelatorio<TransacaoOutputDto> fabricaRelatorio;

        public RelatorioTransacaoService(ITransacaoServices transacaoServices,
                                                    IFabricaRelatorio<TransacaoOutputDto> fabricaRelatorio)
        {
            this.transacaoServices = transacaoServices;
            this.fabricaRelatorio = fabricaRelatorio;
        }

        public async Task<byte[]> GerarRelatorio(string extensao)
        {
            if (string.IsNullOrWhiteSpace(extensao))
                throw new ArgumentNullException("EXTENSÃO NÃO DECLARADA");

            //O "ToList()" PRESERVA O TIPO QUE JÁ EXISTE DENTRO DO "IEnumerable<T>". NO CASO ATUAL, PRESERVA UM "IEnumerable<TransacaoOutputDto>"
            var transacoes = (await transacaoServices.BuscarTransacoes()).ToList();

            var relatorio = fabricaRelatorio.CriarBytes(extensao, transacoes);

            return relatorio.CriarBytes();
        }
    }
}
