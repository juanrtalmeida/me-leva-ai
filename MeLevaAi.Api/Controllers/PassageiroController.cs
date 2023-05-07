using MeLevaAi.Api.Contracts.Requests.Passageiro;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Services;
using Microsoft.AspNetCore.Mvc;
using MeLevaAi.Api.Contracts;
using MeLevaAi.Api.Validations;

namespace MeLevaAi.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PassengerController : ControllerBase
  {

    private readonly PassengerService _passengerService;

    public PassengerController()
    {
      _passengerService = new PassengerService();
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Passageiro))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public ActionResult<Passageiro> Create([FromBody] CriarPassageiroRequest request)
    {
      var newPassenger = _passengerService.Create(request);
      if (!newPassenger.IsValid())
      {
        return NotFound(new ErrorResponse(new Notification("Passenger not found")));
      }
      return Created("Created", newPassenger);
    }

    [HttpPut("{guid}")]
    public ActionResult<Passageiro> AddCredit([FromBody] AdicionarCreditoRequest request)
    {
      var passenger = _passengerService.AddCredit(request);
      if (passenger.Notifications.Any(n => n.Message == "Passageiro não encontrado"))
      {
        return NotFound(new ErrorResponse(new Notification("Passageiro não encontrado")));
      }

      if (passenger.Notifications.Any(n => n.Message == "Valor invalido"))
      {
        return BadRequest(new ErrorResponse(new Notification("Valor invalido, deve ser um valor maior que 0")));
      }

      return Ok(passenger);
    }
  }
}