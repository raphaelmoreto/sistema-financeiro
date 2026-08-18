using SistemaFinanceiro.Application.Interfaces;

namespace SistemaFinanceiro.Application.Services
{
    public class ResponseService : IResponseService
    {
        public bool Sucesso { get; private set; } = false;

        public string Mensagem { get; private set; } = string.Empty;

        public List<string> Notificacoes { get; private set; } = [];

        //==================================================
        // OS MÉTODOS "static" ABAIXO NÃO VAI FAZER COMPARTILHAMENTE DE MÉMORIA PORQUE A CADA CHAMADA ELE RETORNA UMA NOVA INSTÂNCIA DA CLASSE "ResponseService"
        //==================================================
        public static ResponseService Erro(string mensagem, IEnumerable<string>? notificacoes = null)
        {
            return new ResponseService
            {
                Mensagem = mensagem,
                Notificacoes = notificacoes?.ToList() ?? []
            };
        }

        public static ResponseService Ok(string mensagem)
        {
            return new ResponseService
            {
                Sucesso = true,
                Mensagem = mensagem
            };
        }
    }
}
