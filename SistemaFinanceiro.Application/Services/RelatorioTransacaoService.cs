using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Dtos;

namespace SistemaFinanceiro.Application.Services
{
    public class RelatorioTransacaoService : IRelatorioServices
    {
        private readonly ITransacaoServices transacaoServices;
        private readonly IGeradorRelatorio<TransacaoOutputDto> geradorRelatorio;
        private readonly ILerArquivo<TransacaoInputPorArquivoDto> lerArquivo;

        public RelatorioTransacaoService(ITransacaoServices transacaoServices,
                                                        IGeradorRelatorio<TransacaoOutputDto> geradorRelatorio,
                                                        ILerArquivo<TransacaoInputPorArquivoDto> lerArquivo)
        {
            this.transacaoServices = transacaoServices;
            this.geradorRelatorio = geradorRelatorio;
            this.lerArquivo = lerArquivo;
        }

        public async Task<byte[]> GerarRelatorio(string extensao)
        {
            if (string.IsNullOrWhiteSpace(extensao))
                throw new ArgumentNullException("EXTENSÃO NÃO DECLARADA");

            //O "ToList()" PRESERVA O TIPO QUE JÁ EXISTE DENTRO DO "IEnumerable<T>". NO CASO ATUAL, PRESERVA UM "IEnumerable<TransacaoOutputDto>"
            var transacoes = (await transacaoServices.BuscarTransacoes()).ToList();

            var relatorio = geradorRelatorio.CriarBytes(extensao, transacoes);

            return relatorio.CriarBytes();
        }

        public async Task<bool> ImportarArquivo(string extensao, byte[] dados)
        {
            if (string.IsNullOrWhiteSpace(extensao))
                throw new ArgumentNullException("EXTENSÃO NÃO DECLARADA");

            var relatorio = lerArquivo.ExecutarLeitura(extensao, dados);

            var transacoes = relatorio.CriarDados();

            throw new NotImplementedException();
        }
    }
}
