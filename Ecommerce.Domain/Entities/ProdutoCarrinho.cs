using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Entities
{
    public class ProdutoCarrinho
    {
        public ProdutoCarrinho(int produtoId, Produto produto, int carrinhoComprasId, CarrinhoCompras carrinhoCompras)
        {
            ProdutoId = produtoId;
            Produto = produto;
            CarrinhoComprasId = carrinhoComprasId;
            CarrinhoCompras = carrinhoCompras;
        }

        public ProdutoCarrinho() { }

        public int ProdutoId { get; set; }
        [JsonIgnore]
        public Produto Produto { get; set; }
        public int CarrinhoComprasId { get; set; }
        [JsonIgnore]
        public CarrinhoCompras CarrinhoCompras { get; set; }
    }
}
