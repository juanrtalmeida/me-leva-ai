using MeLevaAi.Api.Contracts.Responses.Veiculo;

namespace MeLevaAi.Api.Domain
{
    public class Corrida
    {
        public Corrida(Guid passageiroId, string cordenadaInicialX, string cordenadaInicialY, string cordenadaFinalX, string cordenadaFinalY)
        {
            this.PassageiroId = passageiroId;
            this.CordenadaInicialX = cordenadaInicialX;
            this.CordenadaInicialY = cordenadaInicialY;
            this.CordenadaFinalX = cordenadaFinalX;
            this.CordenadaFinalY = cordenadaFinalY;
        }

        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid PassageiroId { get; private set; }
        public string CordenadaInicialX { get; private set; }
        public string CordenadaInicialY { get; private set; }
        public string CordenadaFinalX { get; private set; }
        public string CordenadaFinalY { get; private set; }
        public Guid VeiculoId { get; internal set; }
        public Guid MotoristaId { get; internal set; }
        public StatusCorrida StatusCorrida { get; internal set; }
        public string TempoEstimado { get; internal set; }
        public Veiculo Veiculo { get; internal set; }

        public Corrida Alterar(Corrida corrida)
        {
            PassageiroId = corrida.PassageiroId;
            CordenadaInicialX = corrida.CordenadaInicialX;
            CordenadaInicialY = corrida.CordenadaInicialY;
            CordenadaFinalX = corrida.CordenadaFinalX;
            CordenadaFinalY = corrida.CordenadaFinalY;
            VeiculoId = corrida.VeiculoId;
            MotoristaId = corrida.MotoristaId;
            StatusCorrida = corrida.StatusCorrida;

            return this;
        }
    }
}
