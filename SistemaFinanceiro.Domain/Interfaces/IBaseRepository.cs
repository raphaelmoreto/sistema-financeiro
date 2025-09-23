
//INTERFACE QUE DEFINE OS MÉTODOS BÁSICOS QUE TODO REPOSITÓRIO TERÁ
namespace SistemaFinanceiro.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<bool> Delete(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task<bool> Insert(T entity);

        Task<bool> Update(T entity);
    }
}
