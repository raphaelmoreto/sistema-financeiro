using SistemaFinanceiro.Domain.Enum;
using SistemaFinanceiro.Domain.Validation;

namespace SistemaFinanceiro.Domain.Entities
{
    public class Transacao : BaseEntity
    {
        public string Descricao { get; private set; } = string.Empty;

        public int FkCategoria { get; private set; }

        public ENaturezaTransacao Natureza { get; private set; }

        public decimal Valor { get; private set; }

        public DateTime DataTransacao { get; private set; }

        public Transacao() { }

        public Transacao(string descricao, int fkCategoria, decimal valor)
        {
            AtribuirDescricao(descricao);
            AtribuirCategoria(fkCategoria);
            AtribuirValor(valor);

            Validar();

            AtribuirNatureza();
            DataTransacao = DateTime.Now;
        }

        public void AtribuirCategoria(int fkCategoria)
        {
            if (fkCategoria <= 0)
            {
                DomainValidationException.When(true, "CATEGORIA INVÁLIDA");
                return;
            }

            if (fkCategoria == FkCategoria)
                return;

            FkCategoria = fkCategoria;
        }

        //public void AtualizarData(DateTime dataTransacao)
        //{
        //    if (DataTransacao == dataTransacao)
        //        return;

        //    DataTransacao = dataTransacao;
        //}

        public void AtribuirDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                DomainValidationException.When(true, "DESCRIÇÃO OBRIGATÓRIA");
                return;
            }

            if (descricao.ToLower() == Descricao.ToLower())
                return;

            Descricao = descricao.ToUpper();
        }

        public void AtribuirNatureza()
        {
            if (Valor < 0)
                Natureza = ENaturezaTransacao.DESPESAS;
            else if (Valor > 0)
                Natureza = ENaturezaTransacao.RECEITAS;
            else
                return;
        }

        public void AtribuirValor(decimal valor)
        {
            if (valor == 0.0m)
            {
                DomainValidationException.When(true, "VALOR NÃO PREENCHIDO");
            }

            if (valor == Valor)
                return;

            Valor = valor;
        }

        public void Validar()
        {
            if (DomainValidationException.TemExcecao())
                throw new AggregateException(DomainValidationException.Notificacoes);
        }
    }
}
