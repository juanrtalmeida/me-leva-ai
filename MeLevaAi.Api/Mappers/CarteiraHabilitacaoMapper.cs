using MeLevaAi.Api.Contracts.Requests.CarteiraHabilitacao;
using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Contracts.Responses.CarteiraHabilitacao;
using MeLevaAi.Api.Domain;

namespace MeLevaAi.Api.Mappers
{
    public static class  CarteiraHabilitacaoMapper
    {
        public static CarteiraHabilitacao ToCarteiraHabilitacao(this CarteiraHabilitacaoResquest request)
            => new(request.Numero, request.Categoria, request.DataVencimento);

        public static CarteiraHabilitacaoDto ToCarteiraHabilitacaoDto(this CarteiraHabilitacao carteira)
        {
            return new CarteiraHabilitacaoDto
            {
                Id = carteira.Id,
                Numero = carteira.Numero,
                Categoria = carteira.Categoria,
                DataVencimento = carteira.DataVencimento,
            };
        }

    }
}
