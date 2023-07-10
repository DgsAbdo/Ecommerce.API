using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Entities
{
    public class Promocao
    {
        public Promocao(string nome, bool promocaoComValorFixo, int quantidade, double valor)
        {
            Nome = nome;
            PromocaoComValorFixo = promocaoComValorFixo;
            Quantidade = quantidade;
            Valor = valor;
        }

        public Promocao(int id, string nome, bool promocaoComValorFixo, int quantidade, double valor)
        {
            Id = id;
            Nome = nome;
            PromocaoComValorFixo = promocaoComValorFixo;
            Quantidade = quantidade;
            Valor = valor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool PromocaoComValorFixo { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; }
    }
}
