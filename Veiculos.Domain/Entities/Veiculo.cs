using Veiculos.Domain.Enum;

namespace Veiculos.Domain.Entities
{
    public class Veiculo
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; } = string.Empty;
        public Marca Marca { get; private set; }
        public string Modelo { get; private set; } = string.Empty;
        public decimal? Valor { get; private set; }

        private Veiculo() { }

        public Veiculo(string descricao, Marca marca, string modelo, decimal? valor)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Marca = marca;
            Modelo = modelo;
            Valor = valor;
        }

        public void Atualizar(string descricao, Marca marca, string modelo, decimal? valor)
        {
            Descricao = descricao;
            Marca = marca;
            Modelo = modelo;
            Valor = valor;
        }
    }
}
