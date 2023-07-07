using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Queries;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repositories
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private readonly DataContext _context;

        public PromocaoRepository(DataContext context)
        {
            _context = context;
        }

        public void Criar(Promocao promocao)
        {
            _context.Promocao.Add(promocao);
            _context.SaveChanges();
        }

        public void Atualizar(Promocao promocao)
        {
            _context.Entry(promocao).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Promocao PegarPorId(int id)
        {
            return _context.Promocao.FirstOrDefault(PromocaoQueries.PegarPromocaoPorID(id));
        }

        public IEnumerable<Promocao> PegarTodasPromocoes()
        {
            return _context.Promocao.AsNoTracking().OrderBy(x => x.Id);
        }

        public void Deletar(int id)
        {
            _context.Promocao.Where(PromocaoQueries.PegarPromocaoPorID(id)).ExecuteDelete();
            _context.SaveChanges();
        }
    }
}
