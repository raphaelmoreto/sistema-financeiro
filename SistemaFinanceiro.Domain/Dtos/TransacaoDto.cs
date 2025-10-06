
namespace SistemaFinanceiro.Domain.Dtos
{
    public record TransacaoInputDto(string Descricao, int FkCategoria, decimal Valor);

    public record TransacaoInputPorArquivoDto(string Descricao, string Categoria, decimal Valor, DateTime Data_Transacao);

    public record TransacaoOutputDto(int Id, string Descricao, string Categoria, string Natureza, decimal Valor, DateTime Data_Transacao);
}
