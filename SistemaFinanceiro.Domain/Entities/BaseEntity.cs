using Dapper.Contrib.Extensions;

namespace SistemaFinanceiro.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; protected set; }

        protected BaseEntity() { }

        protected BaseEntity(int id)
        {
            Id = id;
        }
    }
}
