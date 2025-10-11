using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Dtos;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;

namespace SistemaFinanceiro.Application.Services
{
    public class RelatorioTransacaoService : IRelatorioServices
    {
        private readonly ITransacaoRepository transacaoRepository;
        private readonly IGeradorRelatorio<TransacaoOutputDto> geradorRelatorio;
        private readonly ILerArquivo<Transacao> lerArquivo;

        public RelatorioTransacaoService(ITransacaoRepository transacaoRepository,
                                                        IGeradorRelatorio<TransacaoOutputDto> geradorRelatorio,
                                                        ILerArquivo<Transacao> lerArquivo)
        {
            this.transacaoRepository = transacaoRepository;
            this.geradorRelatorio = geradorRelatorio;
            this.lerArquivo = lerArquivo;
        }

        public async Task<byte[]> GerarRelatorio(string extensao)
        {
            if (string.IsNullOrWhiteSpace(extensao))
                throw new ArgumentNullException("EXTENSÃO NÃO DECLARADA");

            //O "ToList()" PRESERVA O TIPO QUE JÁ EXISTE DENTRO DO "IEnumerable<T>". NO CASO ATUAL, PRESERVA UM "IEnumerable<TransacaoOutputDto>"
            var transacoes = (await transacaoRepository.ListTransacoes()).ToList();

            var relatorio = geradorRelatorio.CriarBytes(extensao, transacoes);

            return relatorio.CriarBytes();
        }

        public async Task<bool> ImportarArquivo(string extensao, byte[] dados)
        {
            if (string.IsNullOrWhiteSpace(extensao))
                throw new ArgumentNullException("EXTENSÃO NÃO DECLARADA");

            var relatorio = lerArquivo.ExecutarLeitura(extensao, dados);

            var transacoes = await relatorio.CriarDados();
            foreach (var transacao in transacoes)
            {
                await transacaoRepository.Insert(transacao);
            }

            throw new NotImplementedException();
        }
    }
}
