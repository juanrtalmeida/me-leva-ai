using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Contracts;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Services;
using Microsoft.AspNetCore.Mvc;
using MeLevaAi.Api.Repositories;
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
    }
}
