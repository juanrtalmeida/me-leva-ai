using MeLevaAi.Api.Contracts;
using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Contracts.Requests.Veiculo;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeLevaAi.Api.Controllers
{
    [ApiController]
    [Route("motorista")]

    public class MotoristaController : Controller
    {
        public readonly MotoristaService _motoristaService;

        public MotoristaController()
        {
            _motoristaService = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotoristaResponseList))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<IEnumerable<Motorista>?> Listar()
        {
            var response = _motoristaService.Listar();

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }


        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotoristaResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<Motorista?> Obter([FromRoute] Guid id)
        {
            var response = _motoristaService.Obter(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotoristaResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<Motorista?> Cadastrar([FromBody] MotoristaRequest request)
        {
            var response = _motoristaService.Cadastrar(request);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotoristaResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public IActionResult Alterar([FromRoute] Guid id, [FromBody] MotoristaRequest request)
        {
            var response = _motoristaService.Alterar(id, request);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<Motorista?> Deletar([FromRoute] Guid id)
        {
            var response = _motoristaService.Deletar(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok();
        }
    }
}
