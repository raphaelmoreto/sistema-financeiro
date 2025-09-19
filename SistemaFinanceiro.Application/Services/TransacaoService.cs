using SistemaFinanceiro.Application.Dtos;
using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;

namespace SistemaFinanceiro.Application.Services
{
    public class TransacaoService : ITransacaoServices
    {
        private readonly ITransacaoRepository transacaoRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            this.transacaoRepository = transacaoRepository;
        }

        public async Task<Transacao> AtualizarTransacao(int id, TransacaoInputDto transacaoInputDto)
        {
            var transacao = await transacaoRepository.SelecionarTransacaoPorId(id);
            if (transacao == null)
                throw new Exception("ERRO!");

            transacao.AtribuirDescricao(transacaoInputDto.Descricao);
            transacao.AtribuirCategoria(transacaoInputDto.FkCategoria);
            transacao.AtribuirValor(transacaoInputDto.Valor);
            transacao.Validar();
            transacao.AtribuirNatureza();

            var result = await transacaoRepository.UpdateTransacao(id, transacao);
            if (!result)
                throw new Exception("ERRO!");

            return transacao;
        }

        public async Task<Transacao> CriarTransacao(TransacaoInputDto transacaoInputDto)
        {
            var transacao = new Transacao
            (
                transacaoInputDto.Descricao,
                transacaoInputDto.FkCategoria,
                transacaoInputDto.Valor
            );

            var result = await transacaoRepository.InserirTransacao(transacao);
            if (!result)
                throw new Exception("ERRO!");

            return transacao;
        }
    }
}
