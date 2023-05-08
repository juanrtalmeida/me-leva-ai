using MeLevaAi.Api.Validations;
using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Responses.Avaliacao
{
    public class AvaliacaoDto
    {
        public Guid Id { get; set; }

        public Guid UsuarioAvaliacaoId { get; set; }

        public Guid CorridaId { get; set; }

        public int Nota { get; set; }
    }
}
