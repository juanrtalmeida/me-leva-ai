using MeLevaAi.Api.Domain;

namespace MeLevaAi.Api.Repositories
{
    public class MotoristaRepository
    {
        private static readonly List<Motorista> _motoristas = new();

        public IEnumerable<Motorista> Listar()
        {
            return _motoristas;
        }

        public Motorista? Obter(Guid id)
            => (from a in _motoristas where a.Id == id select a).FirstOrDefault();

        public Motorista? ObterPorCpf(string cpf)
            => (from a in _motoristas where a.Cpf == cpf select a).FirstOrDefault();

        public Motorista Cadastrar(Motorista motorista)
        {
            _motoristas.Add(motorista);

            return motorista;
        }

        public bool Deletar(Guid id)
        {
            var motorista = Obter(id);

            if (motorista is null)
                return false;

            return _motoristas.Remove(motorista);
        }
    }
}
