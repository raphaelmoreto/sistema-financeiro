using SistemaFinanceiro.Domain.Dtos;
using SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.Domain.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Task<bool> GetByName(string nome);

        Task<IEnumerable<CategoriaOutputDto>> ListCategorias();

        Task<CategoriaOutputDto?> SearchCategoriaById(int id);
    }
}
