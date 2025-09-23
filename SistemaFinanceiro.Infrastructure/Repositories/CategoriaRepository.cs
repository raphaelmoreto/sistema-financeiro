using Dapper;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;
using SistemaFinanceiro.Infrastructure.Interfaces;
using System.Text;

namespace SistemaFinanceiro.Infrastructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(IDatabaseConnection dbConnection) : base(dbConnection) { }

        public async Task<bool> GetByName(string nome)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT COUNT(nome)");
            sb.AppendLine("FROM Categoria");
            sb.AppendLine("WHERE nome = @Categoria");

            var result = await connection.QuerySingleAsync<int>(sb.ToString(), new { Categoria = nome });
            return result > 0;
        }
    }
}
