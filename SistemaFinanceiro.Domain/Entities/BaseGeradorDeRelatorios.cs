using SistemaFinanceiro.Domain.Interfaces;

namespace SistemaFinanceiro.Domain.Entities
{
    public abstract class BaseGeradorDeRelatorios : IGeradorDeRelatorios
    {
        protected List<string> Data { get; }

        protected BaseGeradorDeRelatorios(List<string> data)
        {
            //O "nameof()" O NOME DE UMA VARIÁVEL, TIPO OU MEMBRO COMO UMA STRING DE TEXTO EM TEMPO DE COMPILAÇÃO
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        protected abstract byte[] FormatarDadosEmBytes();

        public byte[] GerarBytesDeRelatorio()
        {
            if (Data == null || Data.Count == 0)
            {
                return Array.Empty<byte>();
            }
            return FormatarDadosEmBytes();
        }
    }
}
