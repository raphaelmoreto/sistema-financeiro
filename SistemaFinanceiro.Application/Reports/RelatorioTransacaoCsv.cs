using System.Text;

namespace SistemaFinanceiro.Application.Reports
{
    public class RelatorioTransacaoCsv : BaseRelatorios
    {
        public RelatorioTransacaoCsv(List<string> dados) : base(dados) { } 

        protected override byte[] FormatadarDadosEmBytes()
        {
            var content = string.Join(Environment.NewLine, Dados);
            return Encoding.UTF8.GetBytes(content);
        }
    }
}
