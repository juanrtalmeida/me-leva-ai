namespace MeLevaAi.Api.Domain
{
    public class Avaliacao
    {
        public Avaliacao(Guid usuarioAvaliacaoId, Guid corridaId, int nota)
        {
            this.UsuarioAvaliacaoId = usuarioAvaliacaoId;
            this.CorridaId = corridaId;
            this.Nota = nota;
        }

        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid UsuarioAvaliacaoId { get; private set; }
        public Guid CorridaId { get; private set; }
        public int Nota { get; private set; }

        public Avaliacao Alterar(Avaliacao avaliacao) {
            UsuarioAvaliacaoId = avaliacao.UsuarioAvaliacaoId;
            CorridaId = avaliacao.CorridaId;
            Nota = avaliacao.Nota;

            return this;
        }
    }
}
