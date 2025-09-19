
namespace SistemaFinanceiro.Application.Dtos
{
    public record TransacaoInputDto(string Descricao, int FkCategoria, decimal Valor);
}
