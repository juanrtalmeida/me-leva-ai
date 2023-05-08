namespace MeLevaAi.Api.Domain
{
  public class Corrida
  {
    public Corrida(Guid passageiroId, double cordenadaInicialX, double cordenadaInicialY, double cordenadaFinalX, double cordenadaFinalY)
    {
      this.PassageiroId = passageiroId;
      this.CordenadaInicialX = cordenadaInicialX;
      this.CordenadaInicialY = cordenadaInicialY;
      this.CordenadaFinalX = cordenadaFinalX;
      this.CordenadaFinalY = cordenadaFinalY;
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid PassageiroId { get; private set; }
    public double CordenadaInicialX { get; private set; }
    public double CordenadaInicialY { get; private set; }
    public double CordenadaFinalX { get; private set; }
    public double CordenadaFinalY { get; private set; }
    public Guid VeiculoId { get; internal set; }
    public Guid MotoristaId { get; internal set; }
    public StatusCorrida StatusCorrida { get; internal set; }
    public TimeSpan TempoEstimado { get; internal set; }
    public Veiculo Veiculo { get; internal set; }

    public DateTime DataInicio { get; private set; }

    public DateTime DataFinalizacao { get; private set; }
    public double Valor { get; private set; }

    public Corrida Alterar(Corrida corrida)
    {
      CordenadaInicialX = corrida.CordenadaInicialX;
      CordenadaInicialY = corrida.CordenadaInicialY;
      CordenadaFinalX = corrida.CordenadaFinalX;
      CordenadaFinalY = corrida.CordenadaFinalY;
      VeiculoId = corrida.VeiculoId;
      MotoristaId = corrida.MotoristaId;
      StatusCorrida = corrida.StatusCorrida;

      return this;
    }

    public Corrida IniciarCorrida(Double valorEstimado, TimeSpan tempoEstimado)
    {
      StatusCorrida = StatusCorrida.INICIADA;
      DataInicio = DateTime.Now;
      TempoEstimado = tempoEstimado;
      return this;
    }

    public Corrida FinalizarCorrida()
    {
      StatusCorrida = StatusCorrida.ENCERRADA;
      DataFinalizacao = DateTime.Now;
      TimeSpan tempoDecorrido = DataFinalizacao - DataInicio;
      Valor = tempoDecorrido.TotalSeconds * 0.2;
      return this;
    }
  }
}
