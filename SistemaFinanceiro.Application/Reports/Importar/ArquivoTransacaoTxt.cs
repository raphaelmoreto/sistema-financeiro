using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;
using System.Globalization;
using System.Text;

namespace SistemaFinanceiro.Application.Reports.Importar
{
    public class ArquivoTransacaoTxt : BaseImportarArquivo<Transacao>, ICriarDados<Transacao>
    {
        public ArquivoTransacaoTxt(ICategoriaRepository categoriaRepository, byte[] dados) : base(categoriaRepository, dados) { }

        protected override async Task<List<Transacao>> ConverterBytesEmDados()
        {
            Lista = [];

            var dados = Encoding.UTF8.GetString(Dados);
            var transacoes = dados.Split(Environment.NewLine);

            for (int i = 0; i < transacoes.Length; i++)
            {
                var transacao = transacoes[i].Split('\t');
                try
                {
                    int fkCategoria = await categoriaRepository.SearchCategoriaByName(transacao[1].Trim());
                    Lista.Add
                    (
                        new Transacao
                        (
                            transacao[0],
                            fkCategoria,
                            decimal.Parse(transacao[3], CultureInfo.InvariantCulture),
                            DateTime.Parse(transacao[4])
                        )
                    );
                }
                catch
                {
                    continue;
                }
            }
            return Lista;
        }
    }
}
