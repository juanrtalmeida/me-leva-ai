using MeLevaAi.Api.Domain;

namespace MeLevaAi.Api.Repositories
{
    public class CorridaRepository
    {
        private static readonly List<Corrida> _corridas = new();

        public IEnumerable<Corrida> Listar()
        {
            return _corridas;
        }

        public Corrida Cadastrar(Corrida corrida)
        {
            _corridas.Add(corrida);

            return corrida;
        }
    }
}
