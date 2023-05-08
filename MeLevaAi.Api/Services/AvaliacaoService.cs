using MeLevaAi.Api.Contracts.Requests.Avaliacao;
using MeLevaAi.Api.Contracts.Requests.Veiculo;
using MeLevaAi.Api.Contracts.Responses.Avaliacao;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Mappers;
using MeLevaAi.Api.Repositories;

namespace MeLevaAi.Api.Services
{
  public class AvaliacaoService
  {
    public readonly AvaliacaoRepository _avaliacaoRepository;
    public readonly CorridaRepository _corridaRepository;

    public AvaliacaoService()
    {
      _avaliacaoRepository = new();
      _corridaRepository = new();
    }

    public AvaliacaoResponse Cadastrar(AvaliacaoRequest request)
    {
      var response = new AvaliacaoResponse();

      var corrida = _corridaRepository.Obter(request.CorridaId);

      var avaliacao = _avaliacaoRepository.ObterPorCorridaEUsuarioAvaliado(request.CorridaId, request.UsuarioAvaliacaoId);

      if (corrida == null)
      {
        response.AddNotification(new Validations.Notification("Corrida não encontrada."));
        return response;
      }

      if (corrida.StatusCorrida != StatusCorrida.ENCERRADA)
      {
        response.AddNotification(new Validations.Notification("Não é possível avaliar, essa corrida ainda não foi finalizada."));
        return response;
      }

      if (avaliacao != null)
      {
        response.AddNotification(new Validations.Notification("Usuario já avaliado"));
        return response;
      }

      if (corrida.PassageiroId == request.UsuarioAvaliacaoId || corrida.MotoristaId == request.UsuarioAvaliacaoId)
      {
        var avaliacaoMapped = request.ToAvaliacao();

        var avaliacaoCriada = _avaliacaoRepository.Cadastrar(avaliacaoMapped);

        response.Avaliacao = avaliacaoCriada.ToAvaliacaoDto();

      }
      else
      {
        response.AddNotification(new Validations.Notification("Não foi encontrado esse usuario"));
        return response;
      }

      return response;
    }
  }
}

