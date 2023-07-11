using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Entities
{
    public class ItemCarrinho
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public int Quantidade { get; set; }
        public int CarrinhoComprasId { get; set; }
        [JsonIgnore]
        public CarrinhoCompras? CarrinhoCompras { get; set; }
    }
}
