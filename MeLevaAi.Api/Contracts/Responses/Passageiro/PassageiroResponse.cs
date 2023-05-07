using MeLevaAi.Api.Validations;

namespace MeLevaAi.Api.Contracts.Responses.Passageiro
{

  public class PassageiroResponse : Notifiable
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string BirthDate { get; set; }
    public string CPF { get; set; }
  }

}