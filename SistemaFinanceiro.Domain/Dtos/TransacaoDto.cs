
namespace SistemaFinanceiro.Domain.Dtos
{
    public record TransacaoInputDto(string Descricao, int FkCategoria, decimal Valor);
}
