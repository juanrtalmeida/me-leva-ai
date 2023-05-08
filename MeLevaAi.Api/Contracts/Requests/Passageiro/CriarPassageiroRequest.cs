using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Requests.Passageiro
{
  public class CriarPassageiroRequest
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public DateOnly BirthDate { get; set; }

    [Required]
    public string CPF { get; set; }
  }
}