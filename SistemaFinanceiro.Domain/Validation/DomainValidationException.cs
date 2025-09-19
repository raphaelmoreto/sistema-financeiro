
namespace SistemaFinanceiro.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        public static List<DomainValidationException> Notificacoes = []; //MESMA COISA QUE "new List<DomainValidationException>();"

        public DomainValidationException(string erro) : base(erro) { }

        public static void When(bool validacao, string mensagem)
        {
            if (validacao)
                Notificacoes.Add(new DomainValidationException(mensagem));
        }

        public static bool TemExcecao() => Notificacoes.Any();
    }
}
