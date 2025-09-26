using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using SistemaFinanceiro.Infrastructure.Interfaces;

namespace SistemaFinanceiro.Infrastructure.Connection
{
    public class DatabaseConnectionSqlServer : IDatabaseConnection
    {
        private readonly IConfiguration configuration; //O 'IConfiguration' CONSEGUE ACESSAR A 'appsettings.json' DE FORMA AUTOMÁTICA

        private readonly string connectionString;

        public DatabaseConnectionSqlServer(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("SqlServerConnectionHouse")!;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
