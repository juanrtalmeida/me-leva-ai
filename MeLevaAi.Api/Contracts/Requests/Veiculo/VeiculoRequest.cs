using MeLevaAi.Api.Domain;
using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Requests.Veiculo
{
    public class VeiculoRequest
    {
        [Required(ErrorMessage = "O campo placa é obrigatório.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo marca é obrigatório.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo modelo é obrigatório.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo ano é obrigatório.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo foto é obrigatório.")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo foto é obrigatório.")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "O campo quantidadeLugares é obrigatório.")]
        public int QuantidadeLugares { get; set; }

        [Required(ErrorMessage = "O campo categoria é obrigatório.")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "O campo proprietarioId é obrigatório.")]
        public Guid ProprietarioId { get; set; }
    }
}
