using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Requests.Motorista
{
  public class RetirarCreditoRequest
  {
    [Required]
    public Guid id { get; set; }

    [Required]
    [Range(0, double.PositiveInfinity)]
    public double valor { get; set; }
  }
}