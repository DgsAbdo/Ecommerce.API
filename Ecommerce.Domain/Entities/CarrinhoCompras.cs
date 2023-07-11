namespace Ecommerce.Domain.Entities
{
    public class CarrinhoCompras
    {
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public ICollection<ItemCarrinho> ItensCarrinho { get; set; }
    }
}
