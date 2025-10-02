using SistemaFinanceiro.Application.Interfaces;

namespace SistemaFinanceiro.Application.Reports
{
    public abstract class BaseRelatorios<T> : IGerarBytes
    {
        protected List<T> Dados {  get; }

        protected BaseRelatorios(List<T> dados)
        {
            //O "nameof()" SERVE PARA OBETER O NOME DE UMA VARIÁVEL, TIPO OU MEMBRO COMO UMA STRING DE TEXTO EM TEMPO DE COMPILAÇÃO
            Dados = dados ?? throw new ArgumentNullException(nameof(dados));
        }

        protected abstract byte[] FormatadarDadosEmBytes();

        public byte[] GerarBytes()
        {
            if (Dados == null || Dados.Count == 0)
            {
                return Array.Empty<byte>();
            }
            return FormatadarDadosEmBytes();
        }
    }
}
