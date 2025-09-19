using SistemaFinanceiro.Application.Dtos;
using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;

namespace SistemaFinanceiro.Application.Services
{
    public class CategoriaService : ICategoriaServices
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> CriarCategoria(CategoriaInputDto categoriaInputDto)
        {
            var categoria = new Categoria(categoriaInputDto.Nome);

            var result = await categoriaRepository.InserirCategoria(categoria);
            if (!result)
                throw new Exception($"ERRO!");

            return categoria;
        }
    }
}
