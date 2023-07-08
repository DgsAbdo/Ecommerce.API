using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Queries;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly DataContext _context;

        public CarrinhoRepository(DataContext context)
        {
            _context = context;
        }

        public void AdicionarProdutoNoCarrinho(Produto produto)
        {
            var carrinhoCompras = BuscarCarrinhoCompras();
            carrinhoCompras.Produtos.Add(produto);

            carrinhoCompras = ImplementarAtributosNoCarrinho(carrinhoCompras);

            AtualizarCarrinho(carrinhoCompras);
        }

        public CarrinhoCompras retornarCarrinhoDeCompras()
        {
            var carrinhoCompras = BuscarCarrinhoCompras();

            if (carrinhoCompras == null)
            {
                CriarCarrinhoCompras();
                carrinhoCompras = BuscarCarrinhoCompras();
            }

            return carrinhoCompras;

        }

        #region Metodos privados

        private CarrinhoCompras ImplementarAtributosNoCarrinho(CarrinhoCompras carrinhoCompras)
        {
            double valorTotal = SomarValorTotalCarrinho(carrinhoCompras);

            carrinhoCompras.ValorTotal = valorTotal;

            int quantidadeItens = SomarQuantidadeItensNoCarrinho(carrinhoCompras);

            throw new NotImplementedException();
        }

        private int SomarQuantidadeItensNoCarrinho(CarrinhoCompras carrinhoCompras)
        {
            throw new NotImplementedException();
        }

        private double SomarValorTotalCarrinho(CarrinhoCompras carrinhoCompras)
        {
            double valorTotal = 0;

            List<Produto> produtosPromocionais= new List<Produto>();
            List<Produto> produtosNaoPromocionais = new List<Produto>();

            foreach (var produto in carrinhoCompras.Produtos)
            {
                if(produto.PromocaoId != null)
                    produtosPromocionais.Add(produto);
                else if(produto.PromocaoId == null)
                    produtosNaoPromocionais.Add(produto);
            };

            if (produtosPromocionais.Any())
                valorTotal += RetornarValorProdutosPromocionais(produtosPromocionais);

            if (produtosNaoPromocionais.Any())
                valorTotal += RetornarValorProdutosNaoPromocionais(produtosNaoPromocionais);
            
            return valorTotal;
        }

        private double RetornarValorProdutosPromocionais(List<Produto> produtosPromocionais)
        {
            double valor = 0;

            //var quantidadePorPromocaoId = produtosPromocionais.GroupBy(p => p.PromocaoId)
            //    .Select(g => new { PromocaoId = g.Key,QuantidadePorItem = g.GroupBy(p => p.Id)
            //    .Select(g => new {ProdutoId = g.Key,Quantidade = g.Count()}).ToList()}).ToList();

            var quantidadePorPromocaoId = produtosPromocionais.GroupBy(p => p.PromocaoId)
                .Select(g => new{PromocaoId = g.Key,Promocao = g.First().Promocao, QuantidadePorItem = g.GroupBy(p => p.Id)
                .Select(g => new{ProdutoId = g.Key,Quantidade = g.Count()}).ToList()}).ToList();


            foreach (var item in quantidadePorPromocaoId)
            {
                var tipoPromocao = item.Promocao.PromocaoComValorFixo;

                switch(tipoPromocao) 
                {
                    case true:
                        {
                            
                          break;
                        }
                    case false:
                        valor = 1;
                        break;
                }

            };

            return valor;
        }

        private double RetornarValorProdutosNaoPromocionais(List<Produto> produtosNaoPromocionais)
        {
            double valor = 0;

            foreach (var produto in produtosNaoPromocionais)
                valor += produto.Preco;

            return valor;
        }

        private void AtualizarCarrinho(CarrinhoCompras carrinhoCompras)
        {
            _context.Entry(carrinhoCompras).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private void CriarCarrinhoCompras()
        {
            var carrinho = new CarrinhoCompras(0, 0);
            _context.Carrinho.Add(carrinho);
            _context.SaveChanges();
        }

        private CarrinhoCompras BuscarCarrinhoCompras()
        {
            return _context.Carrinho.Include(c => c.Produtos).FirstOrDefault(x => x.Id == 1); 
        }
        #endregion
    }
}
