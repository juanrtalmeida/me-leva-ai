using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Validations;

namespace MeLevaAi.Api.Contracts.Responses.Veiculo
{
    public class CorridaResponse : Notifiable
    {
        public CorridaDto Corrida { get; set; }
    }

    public class CorridaResponseList : Notifiable
    {
        public List<CorridaDto>? Corridas { get; set; }
    }
}
