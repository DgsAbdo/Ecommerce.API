using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Queries;

namespace Ecommerce.Test.ProdutoQueriesTestes
{
    [TestClass]
    internal class ProdutoQueriesTest
    {
        private List<Produto> _items;

        public ProdutoQueriesTest()
        {
            _items = new List<Produto>();
            _items.Add(new Produto(1, "camisa", 49.99));
            //_items.Add(new Produto(2, "bone", 39, null));
            //_items.Add(new Produto(3, "bermuda", 120, null));
            //_items.Add(new Produto(4, "tenis", 240, null));
        }

        [TestMethod]        
        public void RetornarProdutoPorId()
        {
            var result = _items.AsQueryable().Where(ProdutoQueries.PegarProdutoPorID(1));
            Assert.AreEqual(_items[0].Id, result.ToList()[0].Id);
        }
    }
}
