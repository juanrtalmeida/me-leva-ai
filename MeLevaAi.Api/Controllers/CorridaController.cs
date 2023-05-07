using MeLevaAi.Api.Validations;
using MeLevaAi.Api.Contracts;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Services;
using Microsoft.AspNetCore.Mvc;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Contracts.Requests.Veiculo;

namespace MeLevaAi.Api.Controllers
{
  [ApiController]
  [Route("corrida")]

  public class CorridaController : Controller
  {
    public readonly CorridaService _corridaService;

    public CorridaController()
    {
      _corridaService = new();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CorridaResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public ActionResult<Corrida?> Cadastrar([FromBody] CorridaRequest request)
    {
      var response = _corridaService.Cadastrar(request);

      if (!response.IsValid())
        return NotFound(new ErrorResponse(response.Notifications));

      return Ok(response);
    }

    [HttpPut("{guid}")]
    [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(CorridaResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public ActionResult<AlterarCorridaResponse> AlterarCorrida([FromRoute] Guid guid)
    {
      var response = _corridaService.AlterarCorrida(guid);

      if (!response.IsValid())
      {
        return NotFound(new ErrorResponse(response.Notifications));
      }
      if (response.Notifications.Any(n => n.Message == "Corrida já finalizada"))
      {
        return BadRequest(new ErrorResponse(new Notification("Corrida já finalizada")));
      }

      if (response.ValorEstimado != null && response.TempoEstimado != null)
      {
        return Accepted(response);
      }

      return Ok(response);
    }
  }

}
