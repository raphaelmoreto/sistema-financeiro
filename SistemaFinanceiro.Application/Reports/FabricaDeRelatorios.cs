using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Application.Reports.Exportar;
using SistemaFinanceiro.Domain.Dtos;

namespace SistemaFinanceiro.Application.Reports
{
    public class FabricaDeRelatorios : IFabricaRelatorio<TransacaoOutputDto>
    {
        //A INTERFACE "IRelatorio CriarBytes(string extensao, List<T> dados)" QUE ESTÁ NO CAMINHO "SistemaFinanceiro.Application.Interfaces" NÃO SE COMPROMETE COM A CLASSE CONCRETA (RelatorioTransacaoTxt, RelatorioTransacaoCsv etc.). ELE SÓ PROMETE QUE VAI ENTREGAR UM OBJETO QUE SABE GERAR BYTES, OU SEJA, QUE IMPLEMENTA A INTERFACE "IRelatorio"

        //EMBORA O RETORNO SEJA DECLARADO COMO "IRelatorio", QUEM VOLTA DE FATO É UMA INSTÂNCIA CONCRETA (RelatorioTransacaoTxt, RelatorioTransacaoCsv, ...)

        public IRelatorio CriarBytes(string extensao, List<TransacaoOutputDto> dados)
        {
            return extensao switch
            {
                ".csv" => new RelatorioTransacaoCsv(dados),
                ".txt" => new RelatorioTransacaoTxt(dados),
                ".xlsx" => new RelatorioTransacaoXlsx(dados),
                _ => throw new ArgumentException("EXTENSÃO NÃO SUPORTADA!")
            };
        }
    }
}
