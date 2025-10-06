
namespace SistemaFinanceiro.Application.Reports.Importar
{
    public abstract class BaseImportarArquivo<T>
    {
        protected byte[] Dados { get;  }

        protected BaseImportarArquivo(byte[] dados)
        {
            Dados = dados ?? throw new ArgumentNullException(nameof(dados));
        }

        protected abstract List<T> ConverterBytesEmDados();

        public List<T> CriarDados()
        {
            if (Dados == null || Dados.Length == 0)
                return []; //LISTA VÁZIA

            return ConverterBytesEmDados();
        }
    }
}
