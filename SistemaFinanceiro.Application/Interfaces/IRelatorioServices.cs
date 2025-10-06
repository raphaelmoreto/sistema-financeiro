
namespace SistemaFinanceiro.Application.Interfaces
{
    public interface IRelatorioServices
    {
        Task<byte[]> GerarRelatorio(string extensao);

        Task<bool> ImportarArquivo(string extensao, byte[] dados);
    }
}
