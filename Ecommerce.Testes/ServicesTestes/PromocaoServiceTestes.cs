using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Services;
using Ecommerce.Testes.Repositories;

namespace Ecommerce.Testes.ServicesTestes
{
    [TestClass]
    public class PromocaoServiceTestes
    {
        private PromocaoService _service { get; set; }
        private PromocaoModel Promocao { get; set; }
        private PromocaoUpdateModel PromocaoUpdate { get; set; }

        [TestInitialize]
        public void Init()
        {
            _service = new PromocaoService(new FakePromocaoRepository());

            Promocao = new PromocaoModel("teste", true, 3, 10);
            PromocaoUpdate = new PromocaoUpdateModel(1, "teste", true, 3, 10);
        }

        [TestMethod]
        public void CriarPromocao_Sucesso()
        {
            var result = _service.CriarPromocao(Promocao);

            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void ModificarPromocao_Sucesso()
        {
            var result = _service.ModificarPromocao(PromocaoUpdate);

            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void DeletarPromocao_Sucesso()
        {
            var result = _service.DeletarPromocao(1);

            Assert.IsTrue(result.Sucesso);
        }
    }
}
