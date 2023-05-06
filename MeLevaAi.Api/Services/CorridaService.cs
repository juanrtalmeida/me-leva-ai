using MeLevaAi.Api.Contracts.Requests.Motorista;
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
        public readonly VeiculoService _veiculoService;

        public CorridaService()
        {
            _corridaRepository = new();
            _veiculoRepository = new();
            _veiculoService = new();
        }

        public CorridaResponse Cadastrar(CorridaRequest request)
        {
            var response = new CorridaResponse();
            var corridaMapped = request.ToCorrida();

            var veiculosLivres = _veiculoRepository.Listar()
                .Where(v => !_corridaRepository.Listar().Any(c => c.VeiculoId == v.Id && c.StatusCorrida == StatusCorrida.INICIADA))
                .ToList();

            if (!veiculosLivres.Any())
            {
                response.AddNotification(new Validations.Notification("Não há veículos disponíveis."));
                return response;
            }

            var veiculoSorteado = SortearVeiculoAleatorio(veiculosLivres);

            corridaMapped.VeiculoId = veiculoSorteado.Id;
            corridaMapped.StatusCorrida = StatusCorrida.INICIADA;

            var corridaCriado = _corridaRepository.Cadastrar(corridaMapped);

            var tempoEstimado = CalcularTempoEstimado();
            corridaCriado.TempoEstimado = tempoEstimado.Minutes.ToString() + " min para a chegada";

            corridaCriado.Veiculo = _veiculoRepository.Obter(corridaCriado.VeiculoId);
            response.Corrida = corridaCriado.ToCorridaDto();

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
    }
}
