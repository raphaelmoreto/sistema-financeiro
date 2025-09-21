using SistemaFinanceiro.Application.Dtos;

namespace SistemaFinanceiro.Application.Interfaces
{
    public interface ICategoriaServices
    {
        Task<CategoriaOutputDto> AtualizarCategoria(int id, CategoriaInputDto categoriaInputDto);

        Task<CategoriaOutputDto> BuscarCategoriaPorId(int id);

        Task<IEnumerable<CategoriaOutputDto>> BuscarCategorias();

        Task<CategoriaOutputDto> CriarCategoria(CategoriaInputDto categoriaInputDto);

        Task<bool> DeletarCategoria(int id);
    }
}
