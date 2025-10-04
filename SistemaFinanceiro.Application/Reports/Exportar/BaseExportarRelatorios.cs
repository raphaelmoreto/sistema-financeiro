
namespace SistemaFinanceiro.Application.Reports.Exportar
{
    public abstract class BaseExportarRelatorios<T>
    {
        protected List<T> Dados {  get; }

        protected BaseExportarRelatorios(List<T> dados)
        {
            //O "nameof()" SERVE PARA OBETER O NOME DE UMA VARIÁVEL, TIPO OU MEMBRO COMO UMA STRING DE TEXTO EM TEMPO DE COMPILAÇÃO
            Dados = dados ?? throw new ArgumentNullException(nameof(dados));
        }

        protected abstract byte[] FormatadarDadosEmBytes();

        public byte[] CriarBytes()
        {
            if (Dados == null || Dados.Count == 0)
            {
                return Array.Empty<byte>();
            }
            return FormatadarDadosEmBytes();
        }
    }
}
