
namespace SistemaFinanceiro.Application.Interfaces
{
    public interface ILerArquivo<T>
    {
        ICriarDados<T> ExecutarLeitura(string extensao, byte[] dados);
    }
}
