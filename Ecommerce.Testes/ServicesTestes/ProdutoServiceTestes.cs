using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Services;
using Ecommerce.Testes.Repositories;

namespace Ecommerce.Testes.ServicesTestes
{
    [TestClass]
    public class ProdutoServiceTestes
    {
        private ProdutoService? _service { get; set; }
        private ProdutoModel Produto { get; set; }
        private ProdutoUpdateModel ProdutoUpdate { get; set; }

        [TestInitialize]
        public void Init()
        {
            _service = new ProdutoService(new FakeProdutoRepository());

            Produto = new ProdutoModel("teste", 10, 1);
            ProdutoUpdate = new ProdutoUpdateModel(1, "teste", 10, 1);
        }

        [TestMethod]
        public void CriarProduto_Sucesso()
        {
            var result = _service.CriarProduto(Produto);

            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void ModificarProduto_Sucesso()
        {
            var result = _service.ModificarProduto(ProdutoUpdate);

            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void Deletar_Sucesso()
        {
            var result = _service.DeletarProduto(1);

            Assert.IsTrue(result.Sucesso);
        }

    }
}
