using MeLevaAi.Api.Domain;
using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Requests.Veiculo
{
    public class CorridaRequest
    {
        [Required(ErrorMessage = "O campo passageiroId é obrigatório.")]
        public Guid PassageiroId { get; set; }

        [Required(ErrorMessage = "O campo cordenadaInicialX é obrigatório.")]
        public string CordenadaInicialX { get; set; }

        [Required(ErrorMessage = "O campo cordenadaInicialY é obrigatório.")]
        public string CordenadaInicialY { get; set; }

        [Required(ErrorMessage = "O campo cordenadaFinalX é obrigatório.")]
        public string CordenadaFinalX { get; set; }

        [Required(ErrorMessage = "O campo cordenadaFinalY é obrigatório.")]
        public string CordenadaFinalY { get; set; }

    }
}
