using Dapper;
using Dapper.Contrib.Extensions;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;
using SistemaFinanceiro.Infrastructure.Interfaces;
using System.Data;
using System.Text;

namespace SistemaFinanceiro.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IDatabaseConnection dbConnection;

        private readonly IDbConnection connection;

        public CategoriaRepository(IDatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.connection = this.dbConnection.GetConnection();
        }

        public async Task<bool> DeleteCategoria(Categoria categoria)
        {
            var result = await connection.DeleteAsync(categoria);
            return result;
        }

        public async Task<int> InsertCategoria(Categoria categoria)
        {
            var result = await connection.InsertAsync(categoria);
            return result;
        }

        public async Task<IEnumerable<Categoria>> SelectAll()
        {
            var result = await connection.GetAllAsync<Categoria>();
            return result;
        }

        public async Task<Categoria> SelectById(int id)
        {
            var result = await connection.GetAsync<Categoria>(id);
            return result;
        }

        public async Task<bool> SelectByName(string categoriaNome)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT COUNT(nome)");
            sb.AppendLine("FROM Categoria");
            sb.AppendLine("WHERE nome = @Categoria");

            var result = await connection.QuerySingleAsync<int>(sb.ToString(), new { Categoria = categoriaNome });
            return result > 0;
        }

        public async Task<bool> UpdateCategoria(Categoria categoria)
        {
            var result = await connection.UpdateAsync(categoria);
            return result;
        }
    }
}
