
namespace SistemaFinanceiro.Application.Reports
{
    public class RelatorioTransacaoCsv : BaseRelatorios
    {
        public RelatorioTransacaoCsv(List<string> dados) : base(dados) { } 

        protected override byte[] FormatadarDadosEmBytes()
        {
            throw new NotImplementedException();
        }
    }
}
