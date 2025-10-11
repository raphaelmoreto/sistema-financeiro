using SistemaFinanceiro.Domain.Interfaces;

namespace SistemaFinanceiro.Application.Reports.Importar
{
    public abstract class BaseImportarArquivo<T>
    {
        protected byte[] Dados { get; }

        protected readonly ICategoriaRepository categoriaRepository;

        protected List<T> Lista;

        protected BaseImportarArquivo(ICategoriaRepository categoriaRepository, byte[] dados)
        {
            this.categoriaRepository = categoriaRepository;
            Dados = dados ?? throw new ArgumentNullException(nameof(dados));
        }

        protected abstract Task<List<T>> ConverterBytesEmDados();

        public async Task<List<T>> CriarDados()
        {
            if (Dados == null || Dados.Length == 0)
                return []; //LISTA VÁZIA

            return await ConverterBytesEmDados();
        }
    }
}
