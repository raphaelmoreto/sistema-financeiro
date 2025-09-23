using Dapper.Contrib.Extensions;
using SistemaFinanceiro.Domain.Enum;
using SistemaFinanceiro.Domain.Validation;

namespace SistemaFinanceiro.Domain.Entities
{
    [Table("Transacao")]
    public class Transacao : BaseEntity
    {
        public string Descricao { get; private set; } = string.Empty;

        public int Fk_Categoria { get; private set; }

        public ENaturezaTransacao Fk_Natureza { get; private set; }

        public decimal Valor { get; private set; }

        public DateTime Data_Transacao { get; private set; }

        public Transacao() { }

        public Transacao(string descricao, int fkCategoria, decimal valor)
        {
            AtribuirDescricao(descricao);
            AtribuirCategoria(fkCategoria);
            AtribuirValor(valor);

            Validar();

            AtribuirNatureza();
            Data_Transacao = DateTime.Now;
        }

        public void AtribuirCategoria(int fkCategoria)
        {
            if (fkCategoria <= 0)
            {
                DomainValidationException.When(true, "CATEGORIA INVÁLIDA");
                return;
            }

            if (fkCategoria == Fk_Categoria)
                return;

            Fk_Categoria = fkCategoria;
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
                Fk_Natureza = ENaturezaTransacao.DESPESAS;
            else if (Valor > 0)
                Fk_Natureza = ENaturezaTransacao.RECEITAS;
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
