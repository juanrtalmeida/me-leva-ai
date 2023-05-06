using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Validations;

namespace MeLevaAi.Api.Contracts.Responses.Veiculo
{
    public class VeiculoResponse : Notifiable
    {
        public VeiculoDto Veiculo { get; set; }
    }

    public class VeiculoResponseList : Notifiable
    {
        public List<VeiculoDto>? Veiculos { get; set; }
    }
}
