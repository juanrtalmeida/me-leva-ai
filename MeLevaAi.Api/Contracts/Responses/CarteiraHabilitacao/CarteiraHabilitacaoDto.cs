using MeLevaAi.Api.Domain;
using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Responses.CarteiraHabilitacao
{
    public class CarteiraHabilitacaoDto
    {
        public Guid Id { get; set; }

        public int Numero { get; set; }

        public Categoria Categoria { get; set; }

        public DateTime DataVencimento { get; set; }
    }
}
