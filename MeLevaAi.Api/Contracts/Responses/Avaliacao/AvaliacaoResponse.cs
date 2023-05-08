using MeLevaAi.Api.Validations;

namespace MeLevaAi.Api.Contracts.Responses.Avaliacao
{
    public class AvaliacaoResponse : Notifiable
    {
        public AvaliacaoDto Avaliacao { get; set; }
    }
}
