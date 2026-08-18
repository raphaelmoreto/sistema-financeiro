
namespace SistemaFinanceiro.Domain.Validation
{
    public abstract class Notifiable<T> where T : Notification
    {
        public List<T> Notificacoes { get; protected set; } = new List<T>();

        public void AddNotification(T notification)
        {
            Notificacoes.Add(notification);
        }

        public bool IsValid
        {
            get
            {
                if (Notificacoes.Count > 0)
                    return false;
                else
                    return true;
            }
        }

        //public IReadOnlyCollection<T> GetNotifications()
        //{
        //    return Notificacoes;
        //}
    }
}
