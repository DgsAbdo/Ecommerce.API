using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Test.QueriesTestes
{
    [TestClass]
    internal class ProdutoQueriesTest
    {
        private List<Produto> _items;

        public ProdutoQueriesTest()
        {
            _items = new List<Produto>();
            _items.Add(new Produto(1, "camisa",49.99, null));
            _items.Add(new Produto(2, "bone", 39, null));
            _items.Add(new Produto(3, "bermuda", 120, null));
            _items.Add(new Produto(4, "tenis", 240, null));
        }

        [TestMethod]
        public void RetornarProdutoPorId(int id) 
        {
            var result = _items.AsQueryable().Where(ProdutoQueries.PegarProdutoPorID(1));
            Assert.AreEqual(_items[0].Id, result.ToList<Produto>()[0].Id);
        }
    }
}
