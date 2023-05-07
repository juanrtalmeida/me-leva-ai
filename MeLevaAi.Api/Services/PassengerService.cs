using MeLevaAi.Api.Repositories;
using MeLevaAi.Api.Contracts.Requests;
using MeLevaAi.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using MeLevaAi.Api.Contracts.Responses;
using MeLevaAi.Api.Validations;

namespace MeLevaAi.Api.Services
{

  public class PassengerService
  {

    private readonly PassengerRepository _passengerRepository;
    public PassengerService() => _passengerRepository = new();

    public CreatePassengerResponse Create(CreatePassengerRequest request)
    {

      if (DateOnly.ParseExact(request.BirthDate, "dd/MM/yyyy").CompareTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-18))) > 0)
      {
        var error = new CreatePassengerResponse();
        error.AddNotification(new Notification("Passenger must Dbe at least 18 years old"));
        return error;
      }

      var passengerRequest = new Passenger(request.Name, request.Email, request.BirthDate, request.CPF);
      var newPassenger = _passengerRepository.Create(passengerRequest);
    }
  }
}