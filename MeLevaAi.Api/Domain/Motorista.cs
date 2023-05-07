namespace MeLevaAi.Api.Domain
{
  public class Motorista
  {
    public Motorista(string nome, string email, DateOnly dataNascimento, string cpf, CarteiraHabilitacao carteiraHabilitacao)
    {
      this.Nome = nome;
      this.Email = email;
      // this.DataNascimento = dataNascimento;
      this.Cpf = cpf;
      this.CarteiraHabilitacao = carteiraHabilitacao;
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateOnly DataNascimento { get; private set; }
    public string Cpf { get; private set; }
    public CarteiraHabilitacao CarteiraHabilitacao { get; private set; }

    public Motorista Alterar(Motorista motorista)
    {
      Nome = motorista.Nome;
      Email = motorista.Email;
      DataNascimento = motorista.DataNascimento;
      Cpf = motorista.Cpf;
      DataNascimento = motorista.DataNascimento;
      CarteiraHabilitacao = motorista.CarteiraHabilitacao;

      return this;
    }
  }
}
