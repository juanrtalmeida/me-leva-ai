using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Requests.Passageiro
{
  public class AdicionarCreditoRequest
  {
    [Required]
    public Guid id { get; set; }

    [Required]
    [Range(0, double.PositiveInfinity)]
    public double valor { get; set; }
  }
}