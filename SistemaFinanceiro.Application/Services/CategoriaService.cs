using SistemaFinanceiro.Domain.Dtos;
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

        public async Task<bool> AtualizarCategoria(int id,CategoriaInputDto categoriaInputDto)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("ID DEVE SER MAIOR QUE ZERO"); //O VALOR DO ID É VÁLIDO, MAS NÃO ESTÁ DENTRO DO INTERVALO MAIOR QUE '0'

            var varificacao = await categoriaRepository.GetByName(categoriaInputDto.Nome);
            if (varificacao)
                throw new InvalidOperationException($"CATEGORIA {categoriaInputDto.Nome} JÁ CADASTRADA NO BANCO");

            var categoria = await categoriaRepository.GetById(id);
            if (categoria == null)
                throw new ArgumentNullException("CATEGORIA NÃO ENCONTRADA!"); //OBJETO NÃO EXISTE

            categoria.AtribuirNome(categoriaInputDto.Nome);
            categoria.Validar();

            var result = await categoriaRepository.Update(categoria);
            if (!result)
                throw new Exception("ERRO");

            return result;
        }

        public async Task<CategoriaOutputDto> BuscarCategoriaPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("ID DEVE SER MAIOR QUE ZERO");

            var categoria = await categoriaRepository.SearchCategoriaById(id);
            if (categoria == null)
                throw new ArgumentNullException("CATEGORIA NÃO ENCONTRADA!");

            return categoria;
        }

        public async Task<IEnumerable<CategoriaOutputDto>> BuscarCategorias()
        {
            var categorias = await categoriaRepository.ListCategorias();
            return categorias;
        }

        public async Task<bool> CriarCategoria(CategoriaInputDto categoriaInputDto)
        {
            var categoria = new Categoria(categoriaInputDto.Nome);

            var varificacao = await categoriaRepository.GetByName(categoria.Nome);
            if (varificacao)
                throw new InvalidOperationException($"CATEGORIA {categoria.Nome} JÁ CADASTRADA NO BANCO");

            var result = await categoriaRepository.Insert(categoria);
            if (!result)
                throw new Exception("ERRO");

            return result;
        }

        public async Task<bool> DeletarCategoria(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("ID DEVE SER MAIOR QUE ZERO");

            var categoria = await categoriaRepository.GetById(id);
            if (categoria == null)
                throw new ArgumentNullException("CATEGORIA NÃO ENCONTRADA!");

            var result = await categoriaRepository.Delete(categoria);
            if (!result)
                throw new Exception("ERRO");

            return result;
        }
    }
}
