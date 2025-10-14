using OfficeOpenXml;
using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;
using System.Globalization;
using System.Text;

namespace SistemaFinanceiro.Application.Reports.Importar
{
    public class ArquivoTransacaoXlsx : BaseImportarArquivo<Transacao>, ICriarDados<Transacao>
    {
        public ArquivoTransacaoXlsx(ICategoriaRepository categoriaRepository, byte[] dados) : base(categoriaRepository, dados) { }

        protected override async Task<List<Transacao>> ConverterBytesEmDados()
        {
            Lista = [];

            using var package = new ExcelPackage(new MemoryStream(Dados));
            var planilha = package.Workbook.Worksheets[0];

            int colunas = planilha.Dimension.End.Column;
            int linhas = planilha.Dimension.End.Row;

            for (int i = 2; i <= linhas; i++)
            {
                string descricao = planilha.Cells[i, 1].Text;
                int fkCategoria = await categoriaRepository.SearchCategoriaByName(planilha.Cells[i, 2].Text);
                decimal valor = decimal.Parse(planilha.Cells[i, 4].Text, NumberStyles.Number, CultureInfo.InvariantCulture);
                DateTime dataTransacao = DateTime.Parse(planilha.Cells[i, 5].Text);

                Lista.Add
                (
                    new Transacao
                    (
                        descricao,
                        fkCategoria,
                        valor,
                        dataTransacao
                    )
                );
            }
            return Lista;
        }
    }
}
