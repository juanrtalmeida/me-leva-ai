namespace MeLevaAi.Api.Domain
{
  public class Passenger
  {
    public Passenger(string name, string email, string birthDate, string cpf)
    {
      Name = name;
      Email = email;
      BirthDate = birthDate;
      CPF = cpf;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public string Email { get; private set; }
    public string Name { get; private set; }

    public string BirthDate { get; private set; }

    public string CPF { get; private set; }
  }
}
