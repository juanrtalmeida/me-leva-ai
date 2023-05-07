using MeLevaAi.Api.Domain;

namespace MeLevaAi.Api.Repositories
{
  public class PassengerRepository
  {
    private static readonly List<Passenger> _passenger = new();
    public Passenger Create(Passenger passenger)
    {
      _passenger.Add(passenger);
      return passenger;
    }
  }
}