namespace MeLevaAi.Api.Domain
{
    public class Veiculo
    {
        public Veiculo(string placa, string marca, string modelo, int ano,string cor, string foto, int quantidadeLugares, Categoria categoria, Guid proprietarioId)
        {
            this.Placa = placa; 
            this.Marca = marca; 
            this.Modelo = modelo;
            this.Ano = ano; 
            this.Cor = cor;
            this.Foto = foto;
            this.QuantidadeLugares = quantidadeLugares;
            this.Categoria = categoria;
            this.ProprietarioId = proprietarioId;
        }
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; set; }
        public string Cor { get; private set; }
        public string Foto { get; private set; }
        public int QuantidadeLugares { get; private set; }
        public Categoria Categoria { get; private set; }
        public Guid ProprietarioId { get; private set; }

        public Veiculo Alterar(Veiculo veiculo)
        {
            Placa = veiculo.Placa;
            Marca = veiculo.Marca;
            Modelo = veiculo.Modelo;
            Ano = veiculo.Ano;
            Cor = veiculo.Cor;
            Foto = veiculo.Foto;
            QuantidadeLugares = veiculo.QuantidadeLugares;
            Categoria = veiculo.Categoria;
            ProprietarioId = veiculo.ProprietarioId;

            return this;
        }
    }
}
