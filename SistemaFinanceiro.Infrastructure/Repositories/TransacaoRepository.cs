using Dapper;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;
using SistemaFinanceiro.Infrastructure.Interfaces;
using System.Data;
using System.Text;

namespace SistemaFinanceiro.Infrastructure.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly IDatabaseConnection dbConnection;

        private readonly IDbConnection connection;

        public TransacaoRepository(IDatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            connection = dbConnection.GetConnection();
        }

        public async Task<bool> UpdateTransacao(int id, Transacao transacao)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE Transacao");
            sb.AppendLine("SET descricao = @Descricao,");
            sb.AppendLine("       valor = @Valor,");
            sb.AppendLine("       fk_categoria = @FkCategoria,");
            sb.AppendLine("       fk_natureza = @Natureza");
            sb.AppendLine("WHERE id = @Id");

            var parameters = new
            {
                Id = id,
                Descricao = transacao.Descricao,
                Valor = transacao.Valor,
                FkCategoria = transacao.FkCategoria,
                Natureza = (int)transacao.Natureza,
            };

            var result = await connection.ExecuteAsync(sb.ToString(), parameters);
            return result > 0;
        }

        public Task<bool> DeletarTransacao(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InserirTransacao(Transacao transacao)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Transacao (descricao, valor, data_transacao, fk_categoria, fk_natureza)");
            sb.AppendLine("                                 VALUES (@Descricao, @Valor, @DataTransacao, @FkCategoria, @Natureza)");

            var parameters = new
            {
                Descricao = transacao.Descricao,
                FkCategoria = transacao.FkCategoria,
                Valor = transacao.Valor,
                Natureza = (int)transacao.Natureza,
                DataTransacao = transacao.DataTransacao,
            };

            var result = await connection.ExecuteAsync(sb.ToString(), parameters);
            return result > 0;
        }

        public async Task<IEnumerable<Transacao>> ListarTransacoes()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT descricao,");
            sb.AppendLine("           valor,");
            sb.AppendLine("           data_transacao,");
            sb.AppendLine("           fk_categoria");
            sb.AppendLine("FROM Transacao");

            return await connection.QueryFirstOrDefault(sb.ToString());
        }

        public async Task<Transacao?> SelecionarTransacaoPorId(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT descricao,");
            sb.AppendLine("           valor,");
            sb.AppendLine("           data_transacao AS 'DataTransacao',");
            sb.AppendLine("           fk_categoria AS 'FkCategoria',");
            sb.AppendLine("           fk_natureza AS 'Natureza'");
            sb.AppendLine("FROM Transacao");
            sb.AppendLine("WHERE id = @Id");

            return await connection.QueryFirstOrDefaultAsync<Transacao>(sb.ToString(), new { Id = id });
        }
    }
}
