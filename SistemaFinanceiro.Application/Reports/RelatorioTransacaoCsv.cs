using SistemaFinanceiro.Domain.Dtos;
using System.Globalization;
using System.Text;

namespace SistemaFinanceiro.Application.Reports
{
    public class RelatorioTransacaoCsv : BaseRelatorios<TransacaoOutputDto>
    {
        public RelatorioTransacaoCsv(List<TransacaoOutputDto> dados) : base(dados) { } 

        protected override byte[] FormatadarDadosEmBytes()
        {
            var dados = Dados.Select(
                t => $"{t.Descricao}; " +
                       $"{t.Categoria}; " +
                       $"{t.Natureza}; " +
                       $"{t.Valor.ToString("F2", CultureInfo.InvariantCulture)}; " +
                       $"{t.Data_Transacao:dd/MM/yyyy}"
            );

            var content = string.Join(Environment.NewLine, dados);
            return Encoding.UTF8.GetBytes(content);
        }
    }
}
