using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Mappers;
using MeLevaAi.Api.Repositories;

namespace MeLevaAi.Api.Services
{
    public class MotoristaService
    {
        public readonly MotoristaRepository _motoristaRepository;

        public MotoristaService()
        {
            _motoristaRepository = new();

        }

        public MotoristaResponse Obter(Guid id)
        {
            var response= new MotoristaResponse();

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

            //_motoristaRepository

            var motoristaMapped = request.ToMotorista();

            var motoristaCriado = _motoristaRepository.Cadastrar(motoristaMapped);


            response.Motorista = motoristaCriado.ToMotoristaDto();

            return response;
        }

        public MotoristaResponse Deletar(Guid id)
        {
            var response = new MotoristaResponse();

            var motorista = _motoristaRepository.Obter(id);

            // if (motorista != null)
            // {
            //     response.AddNotification(new Validations.Notification("Motorista vinculado ao veículo."));
            //return response;
            //}

            _motoristaRepository.Deletar(id);


            return response;
        }

    }
}
