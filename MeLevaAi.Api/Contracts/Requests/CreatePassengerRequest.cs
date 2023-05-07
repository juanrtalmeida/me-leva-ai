using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Requests
{
  public class CreatePassengerRequest
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string BirthDate { get; set; }

    [Required]
    public string CPF { get; set; }
  }
}