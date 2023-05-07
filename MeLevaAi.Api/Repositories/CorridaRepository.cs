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

    public Corrida Obter(Guid corridaId)
    {
      return _corridas.FirstOrDefault(c => c.Id == corridaId);
    }

    public Corrida Alterar(Corrida corrida)
    {
      var corridaIndex = _corridas.FindIndex(c => c.Id == corrida.Id);

      _corridas[corridaIndex] = corrida;

      return corrida;
    }
  }
}