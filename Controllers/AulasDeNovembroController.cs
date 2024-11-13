using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniFatecie.Model.AulaNovembro;
using UniFatecie___13._11._2024.Services;

namespace UniFatecie___13._11._2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NovembroController : ControllerBase
    {
        private readonly ILogger<NovembroController> _logger;
        private readonly INovembroService _service;

        public NovembroController(ILogger<NovembroController> logger, INovembroService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Calcula o percentual de ocupação de uma área construída dentro de uma área de terreno.
        /// </summary>
        /// <param name="larguraAreaConstruida"></param>
        /// <param name="profundidadeAreaConstruida"></param>
        /// <param name="larguraAreaTerreno"></param>
        /// <param name="profundidadeAreaTerreno"></param>
        /// <returns></returns>
       [HttpGet("percentual-de-ocupacao")]
       [SwaggerOperation(Summary = "Calcula o percentual de ocupação de uma área construída dentro de uma área de terreno.", 
                  Description = "O usuário insere a largura e profundidade da área construída e da área de terreno, e o sistema calcula o percentual de ocupação da área construída em relação à área de terreno.")]
        public PercentualDeOcupacaoResponse GetPercentualDeOcupacao([Required]double larguraAreaConstruida, [Required]double profundidadeAreaConstruida,
        [Required]double larguraAreaTerreno, [Required]double profundidadeAreaTerreno, [Required]string zona)
        {
            _logger.LogInformation("Calculando percentual de ocupação...");

            return _service.CalcularPercentualDeOcupacao(larguraAreaConstruida, profundidadeAreaConstruida, larguraAreaTerreno, profundidadeAreaTerreno, zona);
        }
    }
}
