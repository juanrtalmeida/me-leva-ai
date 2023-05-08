using MeLevaAi.Api.Domain;

namespace MeLevaAi.Api.Repositories
{
  public class AvaliacaoRepository
  {
    private static readonly List<Avaliacao> _avaliacoes = new();

    public Avaliacao ObterPorCorridaEUsuarioAvaliado(Guid id, Guid usuarioAvaliado)
        => _avaliacoes.Where(a => a.CorridaId == id && a.UsuarioAvaliacaoId == usuarioAvaliado).FirstOrDefault();


    public Avaliacao Cadastrar(Avaliacao avaliacao)
    {
      _avaliacoes.Add(avaliacao);

      return avaliacao;
    }

  }
}

