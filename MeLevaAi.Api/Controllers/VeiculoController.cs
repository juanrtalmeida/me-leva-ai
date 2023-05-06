using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Contracts;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Services;
using Microsoft.AspNetCore.Mvc;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Contracts.Requests.Veiculo;

namespace MeLevaAi.Api.Controllers
{
    [ApiController]
    [Route("veiculo")]

    public class VeiculoController : Controller
    {
        public readonly VeiculoService _veiculoService;

        public VeiculoController()
        {
            _veiculoService = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoResponseList))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<IEnumerable<Veiculo>?> Listar()
        {
            var response = _veiculoService.Listar();

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<Veiculo?> Obter([FromRoute] Guid id)
        {
            var response = _veiculoService.Obter(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotoristaResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<Veiculo?> Cadastrar([FromBody] VeiculoRequest request)
        {
            var response = _veiculoService.Cadastrar(request);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public IActionResult Alterar([FromRoute] Guid id, [FromBody] VeiculoRequest request)
        {
            var response = _veiculoService.Alterar(id, request);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<Veiculo> Deletar([FromRoute] Guid id)
        {
            var response = _veiculoService.Deletar(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok();
        }
    }
}
