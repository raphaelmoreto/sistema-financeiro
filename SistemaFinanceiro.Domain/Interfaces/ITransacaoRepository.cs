using SistemaFinanceiro.Domain.Dtos;
using SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.Domain.Interfaces
{
    public interface ITransacaoRepository : IBaseRepository<Transacao>
    {
        Task<IEnumerable<TransacaoOutputDto>> ListTransacoes();

        Task<TransacaoOutputDto?> SearchTransacaoById(int id);
    }
}
