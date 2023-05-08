namespace MeLevaAi.Api.Domain
{
    public class CarteiraHabilitacao
    {
        public CarteiraHabilitacao(int numero, Categoria categoria, DateTime dataVencimento)
        {
            this.Numero = numero;
            this.Categoria = categoria;
            this.DataVencimento = dataVencimento;
        }

        public Guid Id { get; init; } = Guid.NewGuid();
        public int Numero { get; private set; }
        public Categoria Categoria { get; private set; }
        public DateTime DataVencimento { get; private set; }

        public CarteiraHabilitacao Alterar(CarteiraHabilitacao carteiraHabilitacao)
        {
            Numero = carteiraHabilitacao.Numero;
            Categoria = carteiraHabilitacao.Categoria;
            DataVencimento = carteiraHabilitacao.DataVencimento;

            return this;
        }
    }
}
