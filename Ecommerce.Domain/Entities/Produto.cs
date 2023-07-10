using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Entities
{
    public class Produto
    {
        public Produto(string nome, double preco, int? promocaoId)
        {
            Nome = nome;
            Preco = preco;
            PromocaoId = promocaoId;
        }

        public Produto(int id, string nome, double preco, int? promocaoId)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            PromocaoId = promocaoId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int? PromocaoId { get; set; }
        public Promocao? Promocao { get; set; }
        [JsonIgnore]
        public ICollection<ItemCarrinho>? ItensCarrinho { get; set; }
    }
}
