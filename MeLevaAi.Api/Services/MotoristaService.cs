using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Contracts.Requests.Veiculo;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Mappers;
using MeLevaAi.Api.Repositories;

namespace MeLevaAi.Api.Services
{
    public class MotoristaService
    {
        public readonly MotoristaRepository _motoristaRepository;
        public readonly VeiculoRepository _veiculoRepository;

        public MotoristaService()
        {
            _motoristaRepository = new();
            _veiculoRepository = new();
        }

        public MotoristaResponseList Listar()
        {
            var response = new MotoristaResponseList();
            var motoristas = _motoristaRepository.Listar();

            if (!motoristas.Any())
            {
                response.AddNotification(new Validations.Notification("Nenhum motorista encontrado"));
                return response;
            }

            var motoristasMapped = motoristas.Select(m => m.ToMotoristaDto()).ToList();
            response.Motoristas = motoristasMapped;

            return response;
        }

        public MotoristaResponse Obter(Guid id)
        {
            var response = new MotoristaResponse();

            var motorista = _motoristaRepository.Obter(id);

            if (motorista == null)
            {
                response.AddNotification(new Validations.Notification("Motorista não encontrado"));
                return response;
            }

            return response;
        }

        public MotoristaResponse Cadastrar(MotoristaRequest request)
        {
            var response = new MotoristaResponse();

            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - request.DataNascimento.Year;

            if (dataAtual.Month < request.DataNascimento.Month || (dataAtual.Month == request.DataNascimento.Month && dataAtual.Day < request.DataNascimento.Day))
            {
                idade--;
            }

            if (idade < 18)
            {
                response.AddNotification(new Validations.Notification("O passageiro deve ter pelo menos 18 anos de idade."));
                return response;
            }

            if (request.CarteiraHabilitacao.DataVencimento < dataAtual)
            {
                response.AddNotification(new Validations.Notification("A carteira de habilitacao está vencida."));
                return response;
            }

            if (!request.Email.Contains("@") || !request.Email.Contains(".com"))
            {
                response.AddNotification(new Validations.Notification("Formato do email é invalido."));
                return response;
            }

            if (request.Cpf.Length < 11)
            {
                response.AddNotification(new Validations.Notification("CPF invalido."));
                return response;
            }

            var motoristaCpf = _motoristaRepository.ObterPorCpf(request.Cpf);

            if (motoristaCpf != null)
            {
                response.AddNotification(new Validations.Notification("CPF já cadastrado"));
                return response;
            }

            var motoristaMapped = request.ToMotorista();

            var motoristaCriado = _motoristaRepository.Cadastrar(motoristaMapped);


            response.Motorista = motoristaCriado.ToMotoristaDto();

            return response;
        }

        public MotoristaResponse Alterar(Guid id, MotoristaRequest request)
        {
            var response = new MotoristaResponse();

            var motoristaAtual = _motoristaRepository.Obter(id);

            if (motoristaAtual is null)
            {
                response.AddNotification(new Validations.Notification("Motorista não foi encontrado."));
                return response;
            }

            var motoristaNovo = request.ToMotorista();

            motoristaNovo.Alterar(motoristaAtual);

            response.Motorista = motoristaNovo.ToMotoristaDto();

            return response;
        }

        public MotoristaResponse Deletar(Guid id)
        {
            var response = new MotoristaResponse();

            var motorista = _motoristaRepository.Obter(id);

            if (motorista == null)
            {
                response.AddNotification(new Validations.Notification("Motorista não encontrado."));
                return response;
            }


            var veiculo = _veiculoRepository.ObterPorProprietarioId(motorista.Id);

            if (veiculo != null)
            {
                response.AddNotification(new Validations.Notification("Motorista vinculado á algum veículo."));
                return response;
            }
 
            _motoristaRepository.Deletar(id); 


            return response;
        }

    }
}
