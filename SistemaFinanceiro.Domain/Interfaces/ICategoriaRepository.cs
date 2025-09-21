using SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<bool> DeleteCategoria(Categoria categoria);

        Task<int> InsertCategoria(Categoria categoria);

        Task<IEnumerable<Categoria>> SelectAll();

        Task<Categoria> SelectById(int id);

        Task<bool> SelectByName(string categoriaNome);

        Task<bool> UpdateCategoria(Categoria categoria);
    }
}
