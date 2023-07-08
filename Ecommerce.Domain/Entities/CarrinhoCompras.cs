using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Entities
{
    public class CarrinhoCompras
    {
        public CarrinhoCompras(double valorTotal, int quantidadeProdutos)
        {
            Id = 1;
            ValorTotal = valorTotal;
            QuantidadeProdutos = quantidadeProdutos;
            Produtos = new List<Produto>();
        }

        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public int QuantidadeProdutos { get; set; }
        public List<Produto> Produtos{ get; set; }
    }
}
