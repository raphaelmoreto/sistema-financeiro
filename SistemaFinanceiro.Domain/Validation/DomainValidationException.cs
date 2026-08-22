
namespace SistemaFinanceiro.Domain.Validation
{
    //==================================================
    // MÉTODO ANTIGO DE VALIDAÇÃO DE ENTIDADES. DEIXEI DE USAR PORQUE MÉTODOS "static" PERTENCE A PRÓPRIA CLASSE E NÃO A UM OBJETO OU INTÂNCIA ESPECIFICA. SENDO ASSIM, "Notificacoes" PODIA RETORNAR MENSAGENS DE ENTIDADES DIFERENTES
    //==================================================
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
