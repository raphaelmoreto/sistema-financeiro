using SistemaFinanceiro.Domain.Dtos;

namespace SistemaFinanceiro.Application.Interfaces
{
    public interface ITransacaoServices
    {
        Task<IResponseService> AtualizarTransacao(int id, TransacaoInputDto transacaoInputDto);

        Task<TransacaoOutputDto?> BuscarTransacaoPorId(int id);

        Task<IEnumerable<TransacaoOutputDto?>> BuscarTransacoes();

        Task<IResponseService> CriarTransacao(TransacaoInputDto transacaoInputDto);

        Task<IResponseService> DeleteTransacao(int id);
    }
}
