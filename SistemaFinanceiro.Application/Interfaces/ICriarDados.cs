
namespace SistemaFinanceiro.Application.Interfaces
{
    public interface ICriarDados<T>
    {
        Task<List<T>> CriarDados();
    }
}
