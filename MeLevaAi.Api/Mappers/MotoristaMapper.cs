using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Contracts.Responses.Motorista;
using MeLevaAi.Api.Domain;

namespace MeLevaAi.Api.Mappers
{
    public static class MotoristaMapper
    {
        public static Motorista ToMotorista(this MotoristaRequest request)
            => new(request.Nome, request.Email, request.DataNascimento, request.Cpf, CarteiraHabilitacaoMapper.ToCarteiraHabilitacao(request.CarteiraHabilitacao));

        public static MotoristaDto
            ToMotoristaDto(this Motorista motorista)
        {
            return new MotoristaDto
            {
                Id = motorista.Id,
                Nome = motorista.Nome,
                Email = motorista.Email,
                DataNascimento = motorista.DataNascimento,
                Cpf = motorista.Cpf,
                CarteiraHabilitacao = CarteiraHabilitacaoMapper.ToCarteiraHabilitacaoDto(motorista.CarteiraHabilitacao)
            };
        }
    }
}
