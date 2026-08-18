using SistemaFinanceiro.Domain.Validation;

namespace SistemaFinanceiro.Application.Interfaces
{
    public interface IResponseService
    {
        bool Sucesso {  get; }

        string Mensagem {  get; }

        public List<string> Notificacoes { get; }
    }
}
