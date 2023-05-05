using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Validations;

namespace MeLevaAi.Api.Contracts.Responses.Veiculo
{
    public class VeiculoDto 
    {
        public Guid Id { get; set; }

        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Ano { get; set; }

        public string Cor { get; set; }

        public string Foto { get; set; }

        public int QuantidadeLugares { get; set; }

        public Categoria Categoria { get; set; }

        public Guid ProprietarioId { get; set; }

    }
}
