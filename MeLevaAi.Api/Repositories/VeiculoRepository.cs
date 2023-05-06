using MeLevaAi.Api.Domain;
using System.Xml.Linq;

namespace MeLevaAi.Api.Repositories
{
    public class VeiculoRepository
    {
        private static readonly List<Veiculo> _veiculos = new();

        public IEnumerable<Veiculo> Listar()
        {
            return _veiculos;
        }

        public Veiculo? Obter(Guid id)
            => (from a in _veiculos where a.Id == id select a).FirstOrDefault();

        public Veiculo? ObterPorProprietarioId(Guid id)
            => (from a in _veiculos where a.ProprietarioId == id select a).FirstOrDefault();

        public Veiculo Cadastrar(Veiculo veiculo)
        {
            _veiculos.Add(veiculo);

            return veiculo;
        }

        public bool Deletar(Guid id)
        {
            var veiculo = Obter(id);

            if (veiculo is null)
                return false;

            return _veiculos.Remove(veiculo);
        }
    }

}
