
namespace SistemaFinanceiro.Application.Interfaces
{
    public interface IGerarRelatorio
    {
        Task<byte[]> GerarRelatorio(string extensao);
    }
}
