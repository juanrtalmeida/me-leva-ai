using MeLevaAi.Api.Domain;
using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Requests.CarteiraHabilitacao
{
    public class CarteiraHabilitacaoResquest
    {
        [Required(ErrorMessage = "O campo número da CNH é obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo categoria da CNH é obrigatório.")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "O campo data de validade da CNH é obrigatório.")]
        public DateTime DataVencimento { get; set; }
    }
}
