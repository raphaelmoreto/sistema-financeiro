
namespace SistemaFinanceiro.Application.Interfaces
{
    public interface IGeradorRelatorio<T>
    {
        ICriarBytes CriarBytes(string extensao, List<T> dados);
    }
}
