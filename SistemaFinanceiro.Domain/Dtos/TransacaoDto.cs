
namespace SistemaFinanceiro.Domain.Dtos
{
    public record TransacaoInputDto(string Descricao, int FkCategoria, decimal Valor);

    public record TransacaoOutputDto(int Id, string Descricao, string Categoria, string Natureza, decimal Valor, DateTime Data_Transacao);
}
