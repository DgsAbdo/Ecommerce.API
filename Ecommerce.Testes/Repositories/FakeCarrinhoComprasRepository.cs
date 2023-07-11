using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Testes.Repositories
{
    internal class FakeCarrinhoComprasRepository : ICarrinhoRepository
    {
        public void AtualizarCarrinhoCompras(CarrinhoCompras carrinho)
        {

        }

        public CarrinhoCompras retornarCarrinhoDeCompras()
        {
            return new CarrinhoCompras { Id = 1,
                ItensCarrinho = new List<ItemCarrinho>()
                {
                    new ItemCarrinho
                    {
                        Id= 1,
                        CarrinhoComprasId= 1,
                        ProdutoId= 1,
                        Quantidade=3,
                        Produto = new Produto(1, "Teste", 4, 1)
                        {
                            Promocao = new Promocao("3 por 10", true, 3, 10)
                        }
                    }
                },
                ValorTotal = 10
            };
        }
    }
}
