using MeLevaAi.Api.Contracts.Requests;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Repositories;
using MeLevaAi.Api.Services;
using Microsoft.AspNetCore.Mvc;
using MeLevaAi.Api.Contracts.Responses;
using MeLevaAi.Api.Validations;

namespace MeLevaAi.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PassengerController : ControllerBase
  {

    private readonly PassengerRepository _passengerRepository;
    private readonly PassengerService _passengerService;

    public PassengerController()
    {
      _passengerRepository = new PassengerRepository();
      _passengerService = new PassengerService();
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Passenger))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public ActionResult<Passenger> Create([FromBody] CreatePassengerRequest request)
    {
      var newPassenger = _passengerService.Create(request);
      if (newPassenger == null)
      {
        return NotFound(new ErrorResponse(new Notification("Passenger not found")));
      }
      return Created("", newPassenger);
    }
  }
}