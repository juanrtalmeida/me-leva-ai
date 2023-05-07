using MeLevaAi.Api.Contracts.Requests.CarteiraHabilitacao;
using MeLevaAi.Api.Contracts.Responses.CarteiraHabilitacao;

namespace MeLevaAi.Api.Contracts.Responses.Motorista
{
  public class MotoristaDto
  {
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public DateOnly DataNascimento { get; set; }

    public string Cpf { get; set; }

    public CarteiraHabilitacaoDto CarteiraHabilitacao { get; set; }
  }
}
