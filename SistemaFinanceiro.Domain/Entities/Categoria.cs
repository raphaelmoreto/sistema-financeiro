using SistemaFinanceiro.Domain.Validation;

namespace SistemaFinanceiro.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; private set; }

        public Categoria() { }

        public Categoria(string nome)
        {
            AtribuirNome(nome);
            Validar();
        }

        public void AtribuirNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                DomainValidationException.When(true, "NOME DA CATEGORIA OBRIGATÓRIA");
                return;
            }

            if (nome == Nome)
                return;

            Nome = nome;
        }

        public void Validar()
        {
            if (DomainValidationException.TemExcecao())
                throw new AggregateException(DomainValidationException.Notificacoes);
        }
    }
}
