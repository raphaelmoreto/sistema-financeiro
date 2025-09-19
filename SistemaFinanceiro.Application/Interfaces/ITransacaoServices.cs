using SistemaFinanceiro.Application.Dtos;
using SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.Application.Interfaces
{
    public interface ITransacaoServices
    {
        Task<Transacao> AtualizarTransacao(int id, TransacaoInputDto transacaoInputDto);

        Task<Transacao> CriarTransacao(TransacaoInputDto transacaoInputDto);
    }
}
