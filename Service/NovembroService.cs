using UniFatecie.Model.AulaNovembro;

namespace UniFatecie___13._11._2024.Services
{
    public class NovembroService : INovembroService
    {
        private static readonly Dictionary<string, double> ZonaPercentual = new Dictionary<string, double>
        {
            { "N", 25 },
            { "L", 30 },
            { "S", 40 }
        };

        public PercentualDeOcupacaoResponse CalcularPercentualDeOcupacao(double larguraAreaConstruida, double profundidadeAreaConstruida, double larguraAreaTerreno, double profundidadeAreaTerreno, string zona)
        {
            var areaConstruida = larguraAreaConstruida * profundidadeAreaConstruida;
            var areaTerreno = larguraAreaTerreno * profundidadeAreaTerreno;
            var percentualDeOcupacao = areaConstruida / areaTerreno * 100;
            var percentualDeOcupacaoString = (areaConstruida / areaTerreno * 100).ToString("F2") + "%";

            if (!ZonaPercentual.TryGetValue(zona.ToUpper(), out double maxPercentual))
            {
            return CriarResposta("Zona inválida.", areaConstruida, areaTerreno, percentualDeOcupacaoString);
            }

            var mensagem = percentualDeOcupacao <= maxPercentual
            ? "Projeto atende norma de zoneamento do plano diretor."
            : "Revisar Medidas. Projeto NÃO atende norma de zoneamento do plano diretor.";

            return CriarResposta(mensagem, areaConstruida, areaTerreno, percentualDeOcupacaoString);
        }

        private PercentualDeOcupacaoResponse CriarResposta(string mensagem, double areaConstruida, double areaTerreno, string percentualDeOcupacaoString)
        {
            return new PercentualDeOcupacaoResponse
            {
                Mensagem = mensagem,
                AreaConstruida = areaConstruida,
                AreaTerreno = areaTerreno,
                PercentualDeOcupacao = percentualDeOcupacaoString
            };
        }
    }
}