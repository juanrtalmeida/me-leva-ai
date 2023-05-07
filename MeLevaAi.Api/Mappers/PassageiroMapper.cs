using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Contracts.Requests.Passageiro;
using MeLevaAi.Api.Contracts.Responses.Passageiro;

namespace MeLevaAi.Api.Mappers
{
  public static class PassageiroMapper
  {
    public static Passageiro ToPassageiro(this CriarPassageiroRequest request) =>
      new Passageiro(request.Name, request.Email, request.BirthDate, request.CPF);

    public static PassageiroResponse ToPassageiroDto(this Passageiro passageiro) =>
      new PassageiroResponse
      {
        Id = passageiro.Id,
        Name = passageiro.Name,
        Email = passageiro.Email,
        BirthDate = passageiro.BirthDate,
        CPF = passageiro.CPF
      };
  }
}