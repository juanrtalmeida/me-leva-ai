using MeLevaAi.Api.Contracts.Requests.Avaliacao;
using MeLevaAi.Api.Contracts.Requests.Veiculo;
using MeLevaAi.Api.Contracts.Responses.Avaliacao;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Domain;

namespace MeLevaAi.Api.Mappers
{
    public static class AvaliacaoMapper
    {
        public static Avaliacao ToAvaliacao(this AvaliacaoRequest request)
           => new(request.CorridaId, request.UsuarioAvaliacaoId,  request.Nota);

        public static AvaliacaoDto
            ToAvaliacaoDto(this Avaliacao avaliacao)
        {

            return new AvaliacaoDto
            {
                Id = avaliacao.Id,
                Nota = avaliacao.Nota,
                CorridaId = avaliacao.CorridaId,
                UsuarioAvaliacaoId = avaliacao.UsuarioAvaliacaoId   
            };
        }
    }
}
