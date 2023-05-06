using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Validations;
using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Responses.Veiculo
{
    public class CorridaDto 
    {
        public Guid Id { get; set; }

        public Guid PassageiroId { get; set; }

        public VeiculoDto Veiculo { get; set; }

        public string TempoEstimado { get; set; }
    }
}
