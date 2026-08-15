
namespace SistemaFinanceiro.Domain.Validation
{
    public class Notification
    {
        public string Key { get; set; }
        public string Message { get; set; }

        public Notification(string key, string mensagem)
        {
            Key = key;
            Message = mensagem;
        }
    }
}
