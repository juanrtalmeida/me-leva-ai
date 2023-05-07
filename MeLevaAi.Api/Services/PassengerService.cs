using MeLevaAi.Api.Repositories;
using MeLevaAi.Api.Contracts.Responses.Passageiro;
using MeLevaAi.Api.Validations;
using MeLevaAi.Api.Contracts.Requests.Passageiro;
using MeLevaAi.Api.Mappers;

namespace MeLevaAi.Api.Services
{

  public class PassengerService
  {

    private readonly PassageiroRepository _passengerRepository;
    public PassengerService() => _passengerRepository = new();

    public PassageiroResponse Create(CriarPassageiroRequest request)
    {
      var error = new PassageiroResponse();
      if (DateOnly.ParseExact(request.BirthDate, "dd/MM/yyyy").CompareTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-16))) > 0)
      {
        error.AddNotification(new Notification("Passageiro deve ter ao menos 16 anos"));
        return error;
      }

      if (!StringValidation.IsValidEmail(request.Email))
      {
        error.AddNotification(new Notification("Email invalido"));
        return error;
      }

      if (request.CPF.Length != 11)
      {
        error.AddNotification(new Notification("CPF invalido"));
        return error;
      }

      if (_passengerRepository.ObterPorCpf(request.CPF) != null)
      {
        error.AddNotification(new Notification("CPF ja foi registrado"));
        return error;
      }



      var Passageiro = request.ToPassageiro();
      var newPassenger = _passengerRepository.Create(Passageiro);
      return newPassenger.ToPassageiroDto();
    }

    public Notifiable AddCredit(AdicionarCreditoRequest request)
    {
      var n = new Notifiable();

      if (_passengerRepository.ObterPeloId(request.id) == null)
      {
        n.AddNotification(new Notification("Passageiro não encontrado"));
        return n;
      }

      if (request.valor <= 0)
      {
        n.AddNotification(new Notification("Valor invalido"));
        return n;
      }

      var passageiro = _passengerRepository.ObterPeloId(request.id);
      passageiro.AlterarSaldo(request.valor);
      _passengerRepository.Update(passageiro);

      return n;

    }
  }
}