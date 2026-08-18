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

            var connection = CreateConnection();
            return await connection.QuerySingleAsync<int>(sb.ToString(), new { Categoria = nome }) > 0;
        }

        public async override Task<bool> Insert(Categoria categoria)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [dbo].[Categoria] ([nome])");
            sb.AppendLine("SELECT @nomeCategoria");
            sb.AppendLine("WHERE NOT EXISTS (");
            sb.AppendLine("	        SELECT [id]");
            sb.AppendLine("     	FROM [dbo].[Categoria] AS autor");
            sb.AppendLine("     	WHERE autor.nome = @nomeCategoria");
            sb.AppendLine(")");

            var connection = CreateConnection();
            return await connection.ExecuteAsync(sb.ToString(), new { nomeCategoria = categoria.Nome}) > 0;
        }

        public async Task<IEnumerable<CategoriaOutputDto>> ListCategorias()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT id,");
            sb.AppendLine("           nome");
            sb.AppendLine("FROM Categoria");

            var connection = CreateConnection();
            return await connection.QueryAsync<CategoriaOutputDto>(sb.ToString());
        }

        public async Task<CategoriaOutputDto?> SearchCategoriaById(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT id,");
            sb.AppendLine("           nome");
            sb.AppendLine("FROM Categoria");
            sb.AppendLine("WHERE id = @Id");

            var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<CategoriaOutputDto>(sb.ToString(), new { Id = id });
        }

        public async Task<int> SearchCategoriaByName(string categoria)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT id");
            sb.AppendLine("FROM Categoria");
            sb.AppendLine("WHERE nome = @Categoria");

            var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sb.ToString(), new { Categoria = categoria });
        }
    }
}
