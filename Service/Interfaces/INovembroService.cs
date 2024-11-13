using UniFatecie.Model.AulaNovembro;

namespace UniFatecie___13._11._2024.Services
{
    public interface INovembroService
    {
        PercentualDeOcupacaoResponse CalcularPercentualDeOcupacao(double larguraAreaConstruida, double profundidadeAreaConstruida, double larguraAreaTerreno, double profundidadeAreaTerreno, string zona);
    }
}