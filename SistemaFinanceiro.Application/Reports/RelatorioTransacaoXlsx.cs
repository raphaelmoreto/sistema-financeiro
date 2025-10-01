using System.Text;

namespace SistemaFinanceiro.Application.Reports
{
    public class RelatorioTransacaoXlsx : BaseRelatorios
    {
        public RelatorioTransacaoXlsx(List<string> dados) : base(dados) { } 

        protected override byte[] FormatadarDadosEmBytes()
        {
            throw new NotImplementedException();
        }
    }
}
