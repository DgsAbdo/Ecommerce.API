using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Queries;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ecommerce.Infra.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly DataContext _context;

        public CarrinhoRepository(DataContext context)
        {
            _context = context;
        }

        public void AtualizarCarrinhoCompras(CarrinhoCompras carrinho)
        {
            _context.Entry(carrinho).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public CarrinhoCompras retornarCarrinhoDeCompras()
        {
            CarrinhoCompras carrinho = _context.Carrinho.Include(i => i.ItensCarrinho).ThenInclude(p => p.Produto)
                .ThenInclude(pr => pr.Promocao).FirstOrDefault(c => c.Id == 1);
            
            if (carrinho == null)
                carrinho = CriarCarrinhoCompras();
            
            return carrinho;
        }

        private CarrinhoCompras CriarCarrinhoCompras()
        {
            var carrinho = new CarrinhoCompras()
            {
                ValorTotal = 0,
                ItensCarrinho = new List<ItemCarrinho>()
            };

            _context.Carrinho.Add(carrinho);
            _context.SaveChanges();

            return carrinho;
        }
    }
}
