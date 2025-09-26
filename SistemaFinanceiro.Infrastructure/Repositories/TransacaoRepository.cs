using Dapper;
using SistemaFinanceiro.Domain.Dtos;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;
using SistemaFinanceiro.Infrastructure.Interfaces;
using System.Data;
using System.Text;

namespace SistemaFinanceiro.Infrastructure.Repositories
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(IDatabaseConnection dbConnection) : base(dbConnection) { }

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
            sb.AppendLine("LEFT JOIN NaturezaTransacao n ON t.fk_natureza = n.id");
            sb.AppendLine("WHERE t.id = @Id");

            return await connection.QueryFirstOrDefaultAsync<TransacaoOutputDto>(sb.ToString(), new { Id = id });
        }
    }
}
