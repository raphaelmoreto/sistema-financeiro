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

        public DateTime Data_Transacao { get; private set; } = DateTime.Now;

        public Transacao() { }

        public Transacao(string descricao, int fkCategoria, decimal valor)
        {
            AtribuirDescricao(descricao);
            AtribuirCategoria(fkCategoria);
            AtribuirValor(valor);
            AtribuirNatureza();
        }

        public Transacao(string descricao, int fkCategoria, decimal valor, DateTime dataTransacao)
        {
            AtribuirDescricao(descricao);
            AtribuirCategoria(fkCategoria);
            AtribuirValor(valor);
            AtribuirNatureza();
            AtribuirData(dataTransacao);
        }

        public void AtribuirCategoria(int fkCategoria)
        {
            if (fkCategoria <= 0)
            {
                AddNotification(new Notification("FK_Categoria", "CATEGÓRIA É OBRIGATÓRIA"));
                return;
            }

            if (fkCategoria == Fk_Categoria)
                return;

            Fk_Categoria = fkCategoria;
        }

        public void AtribuirData(DateTime dataTransacao)
        {
            if (Data_Transacao == dataTransacao)
                return;

            Data_Transacao = dataTransacao;
        }

        public void AtribuirDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                AddNotification(new Notification("Descriçao", "DESCRIÇÃO É OBRIGATÓRIA"));
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
                AddNotification(new Notification("Valor", "VALOR NÃO PREENCHIDO"));
                return;
            }

            if (valor == Valor)
                return;

            Valor = valor;
        }

        public override bool Validar()
        {
            return IsValid;
        }
    }
}
