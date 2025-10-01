using SistemaFinanceiro.Application.Interfaces;

namespace SistemaFinanceiro.Application.Reports
{
    public abstract class BaseRelatorios : IGerarBytes
    {
        protected List<string> Data { get; }

        protected BaseRelatorios(List<string> data)
        {
            //O "nameof()" O NOME DE UMA VARIÁVEL, TIPO OU MEMBRO COMO UMA STRING DE TEXTO EM TEMPO DE COMPILAÇÃO
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        protected abstract byte[] FormatarDadosEmBytes();

        public byte[] GerarBytes()
        {
            if (Data == null || Data.Count == 0)
            {
                return Array.Empty<byte>();
            }
            return FormatarDadosEmBytes();
        }
    }
}
