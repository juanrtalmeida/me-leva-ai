using MeLevaAi.Api.Domain;
using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Requests.Avaliacao
{
    public class AvaliacaoRequest
    {
        [Required(ErrorMessage = "O campo número do usuarioAvaliacaoId é obrigatório.")]
        public Guid UsuarioAvaliacaoId { get; set; }

        [Required(ErrorMessage = "O campo número do corridaId é obrigatório.")]
        public Guid CorridaId { get; set; }

        [Required(ErrorMessage = "O campo número do nota é obrigatório.")]
        public int Nota { get; set; }
    }
}
