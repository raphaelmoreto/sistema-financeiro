
namespace SistemaFinanceiro.Application.Interfaces
{
    public interface IFabricaRelatorio<T>
    {
        IRelatorio CriarBytes(string extensao, List<T> dados);
    }
}
