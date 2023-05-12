using MeLevaAi.Api.Contracts.Requests.Veiculo;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Domain;
using MeLevaAi.Api.Mappers;
using MeLevaAi.Api.Repositories;

namespace MeLevaAi.Api.Services
{
    public class CorridaService
    {
        public readonly CorridaRepository _corridaRepository;
        public readonly VeiculoRepository _veiculoRepository;
        public readonly PassageiroRepository _passageiroRepository;
        public readonly VeiculoService _veiculoService;
        public readonly MotoristaRepository _motoristaRepository;

        public CorridaService()
        {
            _corridaRepository = new();
            _veiculoRepository = new();
            _veiculoService = new();
            _passageiroRepository = new();
            _motoristaRepository = new();
        }

        public CorridaResponse Cadastrar(CorridaRequest request)
        {
            var response = new CorridaResponse();
            var corridaMapped = request.ToCorrida();
            var passageiro = _passageiroRepository.ObterPeloId(request.PassageiroId);

            if (passageiro == null)
            {
                response.AddNotification(new Validations.Notification("Esse passageiro não existe."));
                return response;
            }

            var veiculosLivres = _veiculoRepository.Listar()
                .Where(v => !_corridaRepository.Listar().Any(c => c.VeiculoId == v.Id && c.StatusCorrida == StatusCorrida.AGUARDANDO))
                .ToList();

            if (!veiculosLivres.Any())
            {
                response.AddNotification(new Validations.Notification("Não há veículos disponíveis."));
                return response;
            }

            var veiculoSorteado = SortearVeiculoAleatorio(veiculosLivres);

            corridaMapped.CriandoCorrida(veiculoSorteado.Id, veiculoSorteado.ProprietarioId);

            var corridaCriado = _corridaRepository.Cadastrar(corridaMapped);

            var tempoEstimado = CalcularTempoEstimado();

            corridaCriado.TempoEstimadoCorrida(tempoEstimado);

            var veiculoCorrida= _veiculoRepository.Obter(corridaCriado.VeiculoId);
            corridaCriado.VeiculoDaCorrida(veiculoCorrida);

            response.Corrida = corridaCriado.ToCorridaDto();

            return response;
        }

        public AlterarCorridaResponse AlterarCorrida(Guid guid)
        {
            var response = new AlterarCorridaResponse();
            var corrida = _corridaRepository.Obter(guid);

            if (corrida == null)
            {
                response.AddNotification(new Validations.Notification("Corrida não existe."));
                return response;
            }


            if (corrida.StatusCorrida == StatusCorrida.ENCERRADA)
            {
                response.AddNotification(new Validations.Notification("Corrida já encerrada."));
                return response;
            }

            if (corrida.StatusCorrida == StatusCorrida.INICIADA)
            {
                var passageiro = _passageiroRepository.ObterPeloId(corrida.PassageiroId);
                var motorista = _motoristaRepository.Obter(corrida.MotoristaId);
                if (passageiro.Saldo < corrida.Valor)
                {
                    response.AddNotification(new Validations.Notification("Saldo insuficiente."));
                    return response;
                }

                corrida.FinalizarCorrida();
                passageiro.AlterarSaldo(passageiro.Saldo - corrida.Valor);
                motorista.AlterarSaldo(motorista.Saldo + corrida.Valor);
                _motoristaRepository.Update(motorista);
                _passageiroRepository.Update(passageiro);
                _corridaRepository.Alterar(corrida);
                return response;
            }


            var valorEstimado = CalcularValorEstimadoPreciso(corrida);
            var tempoEstimado = CalcularTempoEstimadoPreciso(corrida);
            corrida.IniciarCorrida(valorEstimado, tempoEstimado);
            return response;
        }

        private Veiculo SortearVeiculoAleatorio(List<Veiculo> veiculos)
        {
            var random = new Random();
            var indice = random.Next(0, veiculos.Count);
            return veiculos[indice];
        }

        private TimeSpan CalcularTempoEstimado()
        {
            var random = new Random();
            var minutos = random.Next(5, 11);
            return TimeSpan.FromMinutes(minutos);
        }

        private TimeSpan CalcularTempoEstimadoPreciso(Corrida corrida)
        {
            var deltaX = Math.Pow(corrida.CordenadaInicialX - corrida.CordenadaFinalX, 2);
            var deltaY = Math.Pow(corrida.CordenadaInicialY - corrida.CordenadaFinalY, 2);
            var distanciaEntreDoisPontos = Math.Sqrt(deltaX + deltaY);
            var velocidade = 30;
            var tempoEstimado = distanciaEntreDoisPontos / velocidade;
            return TimeSpan.FromMinutes(tempoEstimado);
        }

        private double CalcularValorEstimadoPreciso(Corrida corrida)
        {
            var tempoEstimado = CalcularTempoEstimadoPreciso(corrida);
            var valorEstimado = tempoEstimado.TotalSeconds * 0.2;
            return valorEstimado;
        }
    }
}
