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

        public async Task<IResponseService> AtualizarTransacao(int id, TransacaoInputDto transacaoInputDto)
        {
            if (id <= 0)
                return ResponseService.Erro("ID DEVE SER MAIOR QUE ZERO");

            var transacao = await transacaoRepository.GetById(id);
            if (transacao == null)
                return ResponseService.Erro("CATEGORIA NÃO ENCONTRADA!");

            transacao.AtribuirDescricao(transacaoInputDto.Descricao);
            transacao.AtribuirCategoria(transacaoInputDto.FkCategoria);
            transacao.AtribuirValor(transacaoInputDto.Valor);

            if (!transacao.Validar())
                return ResponseService.Erro("ERRO DE VALIDAÇÃO", transacao.Notificacoes.Select(x => x.Message));

            transacao.AtribuirNatureza();

            var result = await transacaoRepository.Update(transacao);
            if (!result)
                return ResponseService.Erro("ERRO AO ATUALIZAR CATEGORIA!");

            return ResponseService.Ok("CATEGORIA ATUALIZADA COM SUCESSO");
        }

        public async Task<TransacaoOutputDto?> BuscarTransacaoPorId(int id)
        {
            var transacao = await transacaoRepository.SearchTransacaoById(id);
            return transacao;
        }

        public async Task<IEnumerable<TransacaoOutputDto?>> BuscarTransacoes()
        {
            var transacoes = await transacaoRepository.ListTransacoes();
            return transacoes;
        }

        public async Task<IResponseService> CriarTransacao(TransacaoInputDto transacaoInputDto)
        {
            var transacao = new Transacao
            (
                transacaoInputDto.Descricao,
                transacaoInputDto.FkCategoria,
                transacaoInputDto.Valor
            );

            if (!transacao.Validar())
                return ResponseService.Erro("ERRO DE VALIDAÇÃO", transacao.Notificacoes.Select(x => x.Message));

            var result = await transacaoRepository.Insert(transacao);
            if (!result)
                return ResponseService.Erro("ERRO AO INSERIR TRANSAÇÃO!");

            return ResponseService.Ok("TRANSAÇÃO INSERIDA COM SUCESSO");
        }

        public async Task<IResponseService> DeleteTransacao(int id)
        {
            if (id <= 0)
                return ResponseService.Erro("ID DEVE SER MAIOR QUE ZERO");

            var transacao = await transacaoRepository.GetById(id);
            if (transacao == null)
                return ResponseService.Erro("TRANSAÇÃO NÃO ENCONTRADA!");

            var result = await transacaoRepository.Delete(transacao);
            if (!result)
                return ResponseService.Erro("ERRO AO DELETAR TRANSAÇÃO!");

            return ResponseService.Ok("TRANSAÇÃO DELETADA COM SUCESSO");
        }
    }
}
