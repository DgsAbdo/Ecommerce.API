﻿using Ecommerce.Domain.Entities;
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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public void Criar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Produto PegarPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(ProdutoQueries.PegarProdutoPorID(id));
        }

        public IEnumerable<Produto> PegarTodos()
        {
            return _context.Produtos.AsNoTracking().OrderBy(x => x.Id);
        }

        public IEnumerable<Produto> PegarTodosComPromocao()
        {
            return _context.Produtos.AsNoTracking().Where(ProdutoQueries.PegarProdutoComPromocao()).OrderBy(x => x.Id);
        }
    }
}
