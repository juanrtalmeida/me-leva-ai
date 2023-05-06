using MeLevaAi.Api.Contracts.Requests.CarteiraHabilitacao;
using MeLevaAi.Api.Contracts.Responses.Motorista;
using MeLevaAi.Api.Validations;

namespace MeLevaAi.Api.Contracts.Requests.Motorista
{
    public class MotoristaResponse : Notifiable
    {
        public MotoristaDto? Motorista { get; set; }
    }

    public class MotoristaResponseList : Notifiable
    {
        public List<MotoristaDto>? Motoristas { get; set; }
    }
}
