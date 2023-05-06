using MeLevaAi.Api.Contracts.Requests.CarteiraHabilitacao;
using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Api.Contracts.Requests.Motorista
{
    public class MotoristaRequest
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo data de nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string Cpf { get; set; }
        
        public CarteiraHabilitacaoResquest CarteiraHabilitacao { get; set; }
    }
}
