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

        public async Task<IResponseService> AtualizarCategoria(int id, CategoriaInputDto categoriaInputDto)
        {
            if (id <= 0)
                return ResponseService.Erro("ID DEVE SER MAIOR QUE ZERO"); //O VALOR DO ID É VÁLIDO, MAS NÃO ESTÁ DENTRO DO INTERVALO MAIOR QUE '0'

            var varificacao = await categoriaRepository.GetByName(categoriaInputDto.Nome);
            if (varificacao)
                return ResponseService.Erro($"CATEGORIA {categoriaInputDto.Nome} JÁ CADASTRADA NO BANCO");

            var categoria = await categoriaRepository.GetById(id);
            if (categoria == null)
                return ResponseService.Erro("CATEGORIA NÃO ENCONTRADA!"); //OBJETO NÃO EXISTE

            categoria.AtribuirNome(categoriaInputDto.Nome);
            if (!categoria.Validar())
                return ResponseService.Erro("ERRO DE VALIDAÇÃO!", categoria.Notificacoes.Select(x => x.Message));

            var result = await categoriaRepository.Update(categoria);
            if (!result)
                return ResponseService.Erro("ERRO AO ATUALIZAR CATEGORIA!");

            return ResponseService.Ok("CATEGORIA ATUALIZADA COM SUCESSO");
        }

        public async Task<CategoriaOutputDto?> BuscarCategoriaPorId(int id)
        {
            var categoria = await categoriaRepository.SearchCategoriaById(id);
            return categoria;
        }

        public async Task<IEnumerable<CategoriaOutputDto?>> BuscarCategorias()
        {
            var categorias = await categoriaRepository.ListCategorias();
            return categorias;
        }

        public async Task<IResponseService> CriarCategoria(CategoriaInputDto categoriaInputDto)
        {
            var categoria = new Categoria(categoriaInputDto.Nome);
            if (!categoria.Validar())
                return ResponseService.Erro("ERRO DE VALIDAÇÃO", categoria.Notificacoes.Select(x => x.Message));

            var varificacao = await categoriaRepository.GetByName(categoria.Nome);
            if (varificacao)
                return ResponseService.Erro($"CATEGORIA {categoria.Nome} JÁ CADASTRADA NO BANCO");

            var result = await categoriaRepository.Insert(categoria);
            if (!result)
                return ResponseService.Erro("ERRO AO INSERIR NO BANCO!");

            return ResponseService.Ok("CATEGORIA INSERIDA COM SUCESSO");
        }

        public async Task<IResponseService> DeletarCategoria(int id)
        {
            if (id <= 0)
                return ResponseService.Erro("ID DEVE SER MAIOR QUE ZERO");

            var categoria = await categoriaRepository.GetById(id);
            if (categoria == null)
                return ResponseService.Erro("CATEGORIA NÃO ENCONTRADA!");

            var result = await categoriaRepository.Delete(categoria);
            if (!result)
                return ResponseService.Erro("ERRO AO DELETAR NO BANCO!");

            return ResponseService.Ok("CATEGORIA DELETADA COM SUCESSO");
        }
    }
}
