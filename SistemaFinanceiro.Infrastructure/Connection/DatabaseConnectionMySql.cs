using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using SistemaFinanceiro.Infrastructure.Interfaces;
using System.Data;

namespace SistemaFinanceiro.Infrastructure.Connection
{
    public class DatabaseConnectionMySql : IDatabaseConnection
    {
        private readonly IConfiguration configuration;

        private readonly string connectionString;

        public DatabaseConnectionMySql(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("TesteNaoUsar")!;
        }

        public IDbConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
