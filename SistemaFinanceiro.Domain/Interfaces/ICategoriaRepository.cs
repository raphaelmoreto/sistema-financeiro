using SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<bool> InserirCategoria(Categoria categoria);
    }
}
