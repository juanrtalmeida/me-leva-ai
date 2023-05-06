using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Contracts.Requests.Veiculo;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Mappers;
using MeLevaAi.Api.Repositories;

namespace MeLevaAi.Api.Services
{
    public class VeiculoService
    {
        public readonly VeiculoRepository _veiculoRepository;
        public readonly MotoristaRepository _motoristaRepository;

        public VeiculoService()
        {
            _veiculoRepository = new();
            _motoristaRepository = new();
        }

        public VeiculoResponseList Listar()
        {
            var response = new VeiculoResponseList();
            var veiculos = _veiculoRepository.Listar();

            if (!veiculos.Any())
            {
                response.AddNotification(new Validations.Notification("Nenhum veiculo encontrado"));
                return response;
            }

            var veiculosMapped = veiculos.Select(v => v.ToVeiculoDto()).ToList();
            response.Veiculos = veiculosMapped;

            return response;
        }

        public VeiculoResponse Obter(Guid id)
        {
            var response = new VeiculoResponse();

            var veiculo = _veiculoRepository.Obter(id);

            if (veiculo == null)
            {
                response.AddNotification(new Validations.Notification("Veiculo não encontrado"));
                return response;
            }

            return response;
        }

        public VeiculoResponse Cadastrar(VeiculoRequest request)
        {
            var response = new VeiculoResponse();


            var motorista = _motoristaRepository.Obter(request.ProprietarioId);

            if (motorista == null)
            {
                response.AddNotification(new Validations.Notification("Esse motorista não existe"));
                return response;
            }


            if (!request.Categoria.Equals(motorista.CarteiraHabilitacao.Categoria))
            {
                response.AddNotification(new Validations.Notification("Esse motorista não possui a categoria para esse veículo"));
                return response;
            }


        var veiculoMapped = request.ToVeiculo();

            var veiculoCriado = _veiculoRepository.Cadastrar(veiculoMapped);


            response.Veiculo = veiculoCriado.ToVeiculoDto();

            return response;
        }

        public VeiculoResponse Alterar(Guid id, VeiculoRequest request)
        {
            var response = new VeiculoResponse();

            var veiculoAtual = _veiculoRepository.Obter(id);

            if (veiculoAtual is null)
            {
                response.AddNotification(new Validations.Notification("Veículo não foi encontrado."));
                return response;
            }

            var veiculoNovo = request.ToVeiculo();

            veiculoNovo.Alterar(veiculoNovo);

            response.Veiculo = veiculoNovo.ToVeiculoDto();

            return response;
        }

        public VeiculoResponse Deletar(Guid id)
        {
            var response = new VeiculoResponse();

            var veiculo = _veiculoRepository.Obter(id);

            if (veiculo == null)
            {
                response.AddNotification(new Validations.Notification("Veiculo não encontrado"));
                return response;
            }

            _veiculoRepository.Deletar(id);


            return response;
        }
    }
}
