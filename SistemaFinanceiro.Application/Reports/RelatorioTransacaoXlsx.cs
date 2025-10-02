using SistemaFinanceiro.Domain.Dtos;

namespace SistemaFinanceiro.Application.Reports
{
    public class RelatorioTransacaoXlsx : BaseRelatorios<TransacaoOutputDto>
    {
        public RelatorioTransacaoXlsx(List<TransacaoOutputDto> dados) : base(dados) { } 

        protected override byte[] FormatadarDadosEmBytes()
        {
            throw new NotImplementedException();
        }
    }
}
