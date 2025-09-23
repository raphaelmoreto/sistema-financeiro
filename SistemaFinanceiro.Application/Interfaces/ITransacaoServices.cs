using SistemaFinanceiro.Domain.Dtos;

namespace SistemaFinanceiro.Application.Interfaces
{
    public interface ITransacaoServices
    {
        Task<bool> AtualizarTransacao(int id, TransacaoInputDto transacaoInputDto);

        Task<TransacaoOutputDto> BuscarTransacaoPorId(int id);

        Task<IEnumerable<TransacaoOutputDto>> BuscarTransacoes();

        Task<bool> CriarTransacao(TransacaoInputDto transacaoInputDto);

        Task<bool> DeleteTransacao(int id);
    }
}
