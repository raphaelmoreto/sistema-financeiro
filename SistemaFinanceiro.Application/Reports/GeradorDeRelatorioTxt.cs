using System.Text;

namespace SistemaFinanceiro.Application.Entities
{
    public class GeradorDeRelatorioTxt : BaseGeradorDeRelatorios
    {
        public GeradorDeRelatorioTxt(List<string> data) : base(data) { }

        protected override byte[] FormatarDadosEmBytes()
        {
            //"string.Join(...) É UM MÉTODO ESTÁTICO DA CLASSE STRING QUE CONCATENA OS ELEMENTOS DE UMA COLEÇÃO (COMO UM ARRAY OU LISTA) NUMA ÚNICA STRING"
            
            //"Environment.NewLine" É UM SEPARADOR QUE GARANTE QUE A QUEBRA DE LINHA SEJA A APROPRIADA PARA O SISTEMA OPERATIVO ONDE O CÓDIGO ESTÁ A SER EXECUTADO. POR EXEMPLO, NO WINDOWS É "\r\n", ENQUANTO EM OUTROS SISTEMAS É '\n' ou '\r'
            var content = string.Join(Environment.NewLine, Data);

            //"Encoding.UTF8" INDICA QUE VOCÊ QUER TRABALHAR COM A CODIFICAÇÃO UTF-8, QUE É UMA FORMA DE TRANSFORMAR CARACTERES EM BYTES

            //".GetBytes(content)" CONVERTE A STRING(content) EM UM ARRAY DE BYTES, USANDO A CODIFICAÇÃO UTF-8
            return Encoding.UTF8.GetBytes(content);
        }
    }
}
