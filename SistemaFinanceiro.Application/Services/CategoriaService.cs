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

        public async Task<CategoriaOutputDto> AtualizarCategoria(int id,CategoriaInputDto categoriaInputDto)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("ID DEVE SER MAIOR QUE ZERO"); //O VALOR DO ID É VÁLIDO, MAS NÃO ESTÁ DENTRO DO INTERVALO MAIOR QUE '0'

            var varificacao = await categoriaRepository.SelectByName(categoriaInputDto.Nome);
            if (varificacao)
                throw new InvalidOperationException($"CATEGORIA {categoriaInputDto.Nome} JÁ CADASTRADA NO BANCO");

            var categoria = await categoriaRepository.SelectById(id);
            if (categoria == null)
                throw new ArgumentNullException("CATEGORIA NÃO ENCONTRADA!"); //OBJETO NÃO EXISTE

            categoria.AtribuirNome(categoriaInputDto.Nome);
            categoria.Validar();

            var result = await categoriaRepository.UpdateCategoria(categoria);
            if (!result)
                throw new Exception("ERRO");

            return new CategoriaOutputDto(categoria.Id, categoria.Nome);
        }

        public async Task<CategoriaOutputDto> BuscarCategoriaPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("ID DEVE SER MAIOR QUE ZERO");

            var categoria = await categoriaRepository.SelectById(id);
            if (categoria == null)
                throw new ArgumentNullException("CATEGORIA NÃO ENCONTRADA!");

            return new CategoriaOutputDto(categoria.Id, categoria.Nome);
        }

        public async Task<IEnumerable<CategoriaOutputDto>> BuscarCategorias()
        {
            List<CategoriaOutputDto> categoriasOutputDtos = [];

            var categorias = await categoriaRepository.SelectAll();
            foreach (var categoria in categorias)
                categoriasOutputDtos.Add(new CategoriaOutputDto(categoria.Id, categoria.Nome));

            return categoriasOutputDtos;
        }

        public async Task<CategoriaOutputDto> CriarCategoria(CategoriaInputDto categoriaInputDto)
        {
            var categoria = new Categoria(categoriaInputDto.Nome);

            var varificacao = await categoriaRepository.SelectByName(categoria.Nome);
            if (varificacao)
                throw new InvalidOperationException($"CATEGORIA {categoria.Nome} JÁ CADASTRADA NO BANCO");

            var idGerado = await categoriaRepository.InsertCategoria(categoria);
            if (idGerado <= 0)
                throw new Exception("ERRO");

            return new CategoriaOutputDto(idGerado, categoriaInputDto.Nome.ToUpper());
        }

        public async Task<bool> DeletarCategoria(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("ID DEVE SER MAIOR QUE ZERO");

            var categoria = await categoriaRepository.SelectById(id);
            if (categoria == null)
                throw new ArgumentNullException("CATEGORIA NÃO ENCONTRADA!");

            var result = await categoriaRepository.DeleteCategoria(categoria);
            if (!result)
                throw new Exception("ERRO");

            return result;
        }
    }
}
