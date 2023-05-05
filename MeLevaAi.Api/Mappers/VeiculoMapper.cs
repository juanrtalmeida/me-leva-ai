using MeLevaAi.Api.Contracts.Requests.Motorista;
using MeLevaAi.Api.Contracts.Requests.Veiculo;
using MeLevaAi.Api.Contracts.Responses.Motorista;
using MeLevaAi.Api.Contracts.Responses.Veiculo;
using MeLevaAi.Api.Domain;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MeLevaAi.Api.Mappers
{
    public static class VeiculoMapper
    {
        public static Veiculo ToVeiculo(this VeiculoRequest request)
           => new(request.Placa, request.Marca, request.Modelo, request.Ano, request.Cor, request.Foto, request.QuantidadeLugares, request.Categoria, request.ProprietarioId);

        public static VeiculoDto
            ToVeiculoDto(this Veiculo veiculo)
        {
            return new VeiculoDto
            {
                Id = veiculo.Id,
                Placa = veiculo.Placa,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Cor = veiculo.Cor,
                QuantidadeLugares = veiculo.QuantidadeLugares,
                Categoria = veiculo.Categoria
            };
        }
    }
}
