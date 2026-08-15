using Dapper.Contrib.Extensions;
using SistemaFinanceiro.Domain.Interfaces;
using SistemaFinanceiro.Infrastructure.Interfaces;
using System.Data;

namespace SistemaFinanceiro.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IDatabaseConnection dbConnection;

        public BaseRepository(IDatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        protected IDbConnection CreateConnection()
        {
            return dbConnection.GetConnection();
        }

        public virtual async Task<bool> Delete(T entity)
        {
            var connection = CreateConnection();
            return await connection.DeleteAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var connection = CreateConnection();
            return await connection.GetAllAsync<T>();
        }

        public virtual async Task<T> GetById(int id)
        {
            var connection = CreateConnection();
            return await connection.GetAsync<T>(id);
        }

        public virtual async Task<bool> Insert(T entity)
        {
            var connection = CreateConnection();
            return await connection.InsertAsync(entity) > 0;
        }

        public virtual async Task<bool> Update(T entity)
        {
            var connection = CreateConnection();
            return await connection.UpdateAsync(entity);
        }
    }
}
