using OfficeOpenXml;
using SistemaFinanceiro.Domain.Dtos;
using System.Globalization;

namespace SistemaFinanceiro.Application.Reports
{
    public class RelatorioTransacaoXlsx : BaseRelatorios<TransacaoOutputDto>
    {
        public RelatorioTransacaoXlsx(List<TransacaoOutputDto> dados) : base(dados) { }

        protected override byte[] FormatadarDadosEmBytes()
        {
            using var package = new ExcelPackage();
            var planilha = package.Workbook.Worksheets.Add("Transacoes");

            planilha.Cells[1, 1].Value = "DESCRIÇÃO";
            planilha.Cells[1, 2].Value = "CATEGORIA";
            planilha.Cells[1, 3].Value = "NATUREZA";
            planilha.Cells[1, 4].Value = "VALOR";
            planilha.Cells[1, 5].Value = "DATA TRANSACAO";

            for (int i = 0; i < Dados.Count; i++)
            {
                var t = Dados[i];
                planilha.Cells[(i + 2), 1].Value = t.Descricao;
                planilha.Cells[(i + 2), 2].Value = t.Categoria;
                planilha.Cells[(i + 2), 3].Value = t.Natureza;
                planilha.Cells[(i + 2), 4].Value = t.Valor;
                planilha.Cells[(i + 2), 5].Value = t.Data_Transacao.ToString("dd/MM/yyyy");
            }
            return package.GetAsByteArray(); //TRANSFORMA PLANILHAS EXCEL EM BYTES
        }
    }
}
