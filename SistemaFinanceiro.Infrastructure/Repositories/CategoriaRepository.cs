using Dapper;
using SistemaFinanceiro.Domain.Dtos;
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

        public async Task<IEnumerable<CategoriaOutputDto>> ListCategorias()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT id,");
            sb.AppendLine("           nome");
            sb.AppendLine("FROM Categoria");

            return await connection.QueryAsync<CategoriaOutputDto>(sb.ToString());
        }

        public async Task<CategoriaOutputDto?> SearchCategoriaPorId(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT id,");
            sb.AppendLine("           nome");
            sb.AppendLine("FROM Categoria");
            sb.AppendLine("WHERE id = @Id");

            return await connection.QueryFirstOrDefaultAsync<CategoriaOutputDto>(sb.ToString(), new { Id = id });
        }
    }
}
