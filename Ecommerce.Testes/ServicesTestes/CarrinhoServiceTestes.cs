using Ecommerce.Domain.Services;
using Ecommerce.Testes.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecommerce.Testes.ServicesTestes
{
    [TestClass]
    public class CarrinhoServiceTestes
    {
        private CarrinhoService? _service { get; set; }

        [TestInitialize]
        public void Init() 
        {
            _service = new CarrinhoService(new FakeCarrinhoComprasRepository(), new FakeProdutoRepository());
        }

        [TestMethod]
        public void AdicionarProdutoNoCarrinho_Sucesso()
        {
            var result = _service.AdicionarProdutoNoCarrinho(1, 3);

            Assert.IsNotNull(result.Dados);
            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void AdicionarProdutoNoCarrinho_Invalido()
        {
            var result = _service.AdicionarProdutoNoCarrinho(0, 2);

            Assert.IsFalse(result.Sucesso);
        }

        [TestMethod]
        public void RemoverProdutoDoCarrinho_Sucesso()
        {
            var result = _service.RemoverProdutoDoCarrinho(1, 2);

            Assert.AreEqual("Item removido do carrinho.", result.Mensagem);
            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void RemoverProdutoDoCarrinho_Invalido()
        {
            var result = _service.RemoverProdutoDoCarrinho(1, 0);

            Assert.IsFalse(result.Sucesso);
        }

        [TestMethod]
        public void LimparProdutosDoCarrinho()
        {
            var result = _service.LimparProdutosDoCarrinho();

            Assert.IsTrue(result.Sucesso);
            Assert.AreEqual("Carrinho limpo com sucesso", result.Mensagem);
        }
    }
}
