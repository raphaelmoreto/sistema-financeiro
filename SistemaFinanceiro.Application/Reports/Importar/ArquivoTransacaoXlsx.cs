using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;

namespace SistemaFinanceiro.Application.Reports.Importar
{
    public class ArquivoTransacaoXlsx : BaseImportarArquivo<Transacao>, ICriarDados<Transacao>
    {
        public ArquivoTransacaoXlsx(ICategoriaRepository categoriaRepository, byte[] dados) : base(categoriaRepository, dados)
        {
        }

        protected override async Task<List<Transacao>> ConverterBytesEmDados()
        {
            throw new NotImplementedException();
        }
    }
}
