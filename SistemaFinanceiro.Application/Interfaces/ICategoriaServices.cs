using SistemaFinanceiro.Domain.Dtos;

namespace SistemaFinanceiro.Application.Interfaces
{
    public interface ICategoriaServices
    {
        Task<IResponseService> AtualizarCategoria(int id, CategoriaInputDto categoriaInputDto);

        Task<CategoriaOutputDto?> BuscarCategoriaPorId(int id);

        Task<IEnumerable<CategoriaOutputDto?>> BuscarCategorias();

        Task<IResponseService> CriarCategoria(CategoriaInputDto categoriaInputDto);

        Task<IResponseService> DeletarCategoria(int id);
    }
}
