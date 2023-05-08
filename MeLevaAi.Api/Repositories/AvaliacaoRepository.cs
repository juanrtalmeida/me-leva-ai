using MeLevaAi.Api.Domain;

namespace MeLevaAi.Api.Repositories
{
    public class AvaliacaoRepository
    {
        private static readonly List<Avaliacao> _avaliacoes = new();

        public Avaliacao? ObterPorCorrida(Guid id)
           => (from a in _avaliacoes where a.CorridaId == id select a).FirstOrDefault();

        public Avaliacao Cadastrar(Avaliacao avaliacao)
        {
            _avaliacoes.Add(avaliacao);

            return avaliacao;
        }
    }
}
