using System.Data;

namespace SistemaFinanceiro.Infrastructure.Interfaces
{
    public interface IDatabaseConnection
    {
        IDbConnection GetConnection();
    }
}
