using Dapper;
using SistemaFinanceiro.Domain.Dtos;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;
using SistemaFinanceiro.Infrastructure.Interfaces;
using System.Text;

namespace SistemaFinanceiro.Infrastructure.Repositories
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(IDatabaseConnection dbConnection) : base(dbConnection) { }

        public override async Task<bool> Insert(Transacao transacao)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [dbo].[Transacao] ([descricao], [valor], [data_transacao], [fk_categoria], [fk_natureza])");
            sb.AppendLine("                                  VALUES (@descricao, @valor, @data_transacao, @fk_categoria, @fk_natureza)");

            var param = new
            {
                transacao.Descricao,
                transacao.Valor,
                transacao.Data_Transacao,
                transacao.Fk_Categoria,
                transacao.Fk_Natureza
            };

            var connection = CreateConnection();
            return await connection.ExecuteAsync(sb.ToString(), param) > 0;
        }

        public async Task<IEnumerable<TransacaoOutputDto>> ListTransacoes()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT t.id,");
            sb.AppendLine("           t.descricao,");
            sb.AppendLine("           c.nome AS 'categoria',");
            sb.AppendLine("           n.natureza,");
            sb.AppendLine("           t.valor,");
            sb.AppendLine("           t.data_transacao");
            sb.AppendLine("FROM Transacao t");
            sb.AppendLine("JOIN Categoria c ON t.fk_categoria = c.id");
            sb.AppendLine("JOIN Natureza n ON t.fk_natureza = n.id");

            var connection = CreateConnection();
            return await connection.QueryAsync<TransacaoOutputDto>(sb.ToString());
        }

        public async Task<TransacaoOutputDto?> SearchTransacaoById(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT t.id,");
            sb.AppendLine("           t.descricao,");
            sb.AppendLine("           c.nome AS 'categoria',");
            sb.AppendLine("           n.natureza,");
            sb.AppendLine("           t.valor,");
            sb.AppendLine("           t.data_transacao");
            sb.AppendLine("FROM Transacao t");
            sb.AppendLine("JOIN Categoria c ON t.fk_categoria = c.id");
            sb.AppendLine("LEFT JOIN Natureza n ON t.fk_natureza = n.id");
            sb.AppendLine("WHERE t.id = @Id");

            var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TransacaoOutputDto>(sb.ToString(), new { Id = id });
        }

        public override async Task<bool> Update(Transacao transacao)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [dbo].[Transacao]");
            sb.AppendLine("SET [descricao] = @descricao");
            sb.AppendLine("    ,[valor] = @valor");
            sb.AppendLine("    ,[data_transacao] = @data_transacao");
            sb.AppendLine("    ,[fk_categoria] = @fk_categoria");
            sb.AppendLine("    ,[fk_natureza] = @fk_natureza");
            sb.AppendLine("WHERE [id] = @id");

            var param = new
            {
                transacao.Descricao,
                transacao.Valor,
                transacao.Data_Transacao,
                transacao.Fk_Categoria,
                transacao.Fk_Natureza,
                transacao.Id
            };

            var connection = CreateConnection();
            return await connection.ExecuteAsync(sb.ToString(), param) > 0;
        }
    }
}
