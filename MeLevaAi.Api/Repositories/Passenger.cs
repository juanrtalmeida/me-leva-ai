using MeLevaAi.Api.Domain;

namespace MeLevaAi.Api.Repositories
{
  public class PassageiroRepository
  {
    private static readonly List<Passageiro> _passenger = new();
    public Passageiro Create(Passageiro passenger)
    {
      _passenger.Add(passenger);
      return passenger;
    }

    public Passageiro ObterPorCpf(string cpf) => _passenger.FirstOrDefault(x => x.CPF == cpf);
    public Passageiro ObterPeloId(Guid id) => _passenger.FirstOrDefault(x => x.Id == id);
  }
}