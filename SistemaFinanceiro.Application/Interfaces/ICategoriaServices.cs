using SistemaFinanceiro.Application.Dtos;
using SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.Application.Interfaces
{
    public interface ICategoriaServices
    {
        Task<Categoria> CriarCategoria(CategoriaInputDto categoriaInputDto);
    }
}
