using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Contracts.Requests.Veiculo;
using MeLevaAi.Api.Contracts.Responses.Motorista;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Domain;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MeLevaAi.Api.Mappers
{
  public static class CorridaMapper
  {
    public static Corrida ToCorrida(this CorridaRequest request)
       => new(request.PassageiroId, request.CordenadaInicialX, request.CordenadaInicialY, request.CordenadaFinalX, request.CordenadaFinalY);

    public static CorridaDto
        ToCorridaDto(this Corrida corrida)
    {

      return new CorridaDto
      {
        Id = corrida.Id,
        PassageiroId = corrida.PassageiroId,
        Veiculo = corrida.Veiculo.ToVeiculoDto(),
        TempoEstimado = corrida.TempoEstimado.TotalMinutes.ToString() + " minutos",
      };
    }
  }
}
