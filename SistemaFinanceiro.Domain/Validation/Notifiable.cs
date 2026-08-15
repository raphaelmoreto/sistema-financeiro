
namespace SistemaFinanceiro.Domain.Validation
{
    public abstract class Notifiable<T> where T : Notification
    {
        private List<T> Notificacoes = new List<T>();

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

        public IReadOnlyCollection<T> GetNotifications()
        {
            return Notificacoes;
        }
    }
}
