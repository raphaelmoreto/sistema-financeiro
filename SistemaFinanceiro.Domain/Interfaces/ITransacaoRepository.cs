using SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.Domain.Interfaces
{
    public interface ITransacaoRepository
    {
        Task<bool> UpdateTransacao(int id, Transacao transacao);

        Task<bool> DeletarTransacao(int id);

        Task<bool> InserirTransacao(Transacao transacao);

        Task<IEnumerable<Transacao>> ListarTransacoes();

        Task<Transacao?> SelecionarTransacaoPorId(int id);
    }
}
