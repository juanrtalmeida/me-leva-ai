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
    public class PassageiroController : ControllerBase
    {
      _passengerService = new PassengerService();
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Passageiro))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public ActionResult<Passageiro> Create([FromBody] CriarPassageiroRequest request)
    {


      var response = _passengerService.Create(request);

      if (!response.IsValid())
        return NotFound(new ErrorResponse(response.Notifications));

      return Ok(response);
    }

    [HttpPut("adicionar-credito")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public ActionResult AddCredit([FromBody] AdicionarCreditoRequest request)
    {
      var passenger = _passengerService.AddCredit(request);
      if (passenger.Notifications.Any(n => n.Message == "Passageiro não encontrado"))
      {
        return NotFound(new ErrorResponse(new Notification("Passageiro não encontrado")));
      }

        public PassageiroController()
        {
            _passengerService = new PassengerService();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Passageiro))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<Passageiro> Create([FromBody] CriarPassageiroRequest request)
        {


            var response = _passengerService.Create(request);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpPut("adicionar-credito")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public ActionResult AddCredit([FromBody] AdicionarCreditoRequest request)
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

            return Accepted(passenger);
        }
    }
}