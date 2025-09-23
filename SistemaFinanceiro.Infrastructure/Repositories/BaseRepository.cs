using Dapper.Contrib.Extensions;
using SistemaFinanceiro.Domain.Interfaces;
using SistemaFinanceiro.Infrastructure.Interfaces;
using System.Data;

namespace SistemaFinanceiro.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IDatabaseConnection dbConnection;

        protected readonly IDbConnection connection;

        public BaseRepository(IDatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.connection = this.dbConnection.GetConnection();
        }

        public virtual async Task<bool> Delete(T entity) => await connection.DeleteAsync(entity);

        public virtual async Task<IEnumerable<T>> GetAll() => await connection.GetAllAsync<T>();

        public virtual async Task<T> GetById(int id) => await connection.GetAsync<T>(id);

        public virtual async Task<bool> Insert(T entity) => await connection.InsertAsync(entity) > 0;

        public virtual async Task<bool> Update(T entity) => await connection.UpdateAsync(entity);
    }
}
