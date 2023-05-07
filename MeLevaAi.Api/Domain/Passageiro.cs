namespace MeLevaAi.Api.Domain
{
  public class Passageiro
  {
    public Passageiro(string name, string email, string birthDate, string cpf)
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

    public double Saldo { get; private set; }

    public Passageiro AlterarSaldo(double novoSaldo)
    {
      Saldo = novoSaldo;

      return this;
    }
  }
}
