using Dapper.Contrib.Extensions;
using SistemaFinanceiro.Domain.Validation;

namespace SistemaFinanceiro.Domain.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        [Key]
        public int Id { get; protected set; }

        public abstract bool Validar();
    }
}
