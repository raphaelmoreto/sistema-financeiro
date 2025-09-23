using SistemaFinanceiro.Domain.Dtos;
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

        public async Task<bool> AtualizarTransacao(int id, TransacaoInputDto transacaoInputDto)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("ID DEVE SER MAIOR QUE ZERO");

            var transacao = await transacaoRepository.GetById(id);
            if (transacao == null)
                throw new ArgumentNullException("CATEGORIA NÃO ENCONTRADA!");

            transacao.AtribuirDescricao(transacaoInputDto.Descricao);
            transacao.AtribuirCategoria(transacaoInputDto.FkCategoria);
            transacao.AtribuirValor(transacaoInputDto.Valor);
            transacao.Validar();
            transacao.AtribuirNatureza();

            var result = await transacaoRepository.Update(transacao);
            if (!result)
                throw new Exception("ERRO!");

            return result;
        }

        public async Task<TransacaoOutputDto> BuscarTransacaoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("ID DEVE SER MAIOR QUE ZERO");

            var transacao = await transacaoRepository.SearchTransacaoById(id);
            if (transacao == null)
                throw new ArgumentNullException("TRANSAÇÃO NÃO ENCONTRADA!");

            return transacao;
        }

        public async Task<IEnumerable<TransacaoOutputDto>> BuscarTransacoes()
        {
            var transacoes = await transacaoRepository.ListTransacoes();
            return transacoes;
        }

        public async Task<bool> CriarTransacao(TransacaoInputDto transacaoInputDto)
        {
            var transacao = new Transacao
            (
                transacaoInputDto.Descricao,
                transacaoInputDto.FkCategoria,
                transacaoInputDto.Valor
            );

            var result = await transacaoRepository.Insert(transacao);
            if (!result)
                throw new Exception("ERRO!");

            return result;
        }

        public async Task<bool> DeleteTransacao(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("ID DEVE SER MAIOR QUE ZERO");

            var transacao = await transacaoRepository.GetById(id);
            if (transacao == null)
                throw new ArgumentNullException("TRANSAÇÃO NÃO ENCONTRADA!");

            var result = await transacaoRepository.Delete(transacao);
            if (!result)
                throw new Exception("ERRO!");

            return result;
        }
    }
}
