using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Testes.Repositories
{
    internal class FakePromocaoRepository : IPromocaoRepository
    {
        public void Atualizar(Promocao produto)
        {

        }

        public void Criar(Promocao produto)
        {

        }

        public void Deletar(int id)
        {

        }

        public Promocao PegarPorId(int id)
        {
            return new Promocao("teste", true, 3, 10);
        }

        public IEnumerable<Promocao> PegarTodasPromocoes()
        {
            return new List<Promocao>()
            {
                new Promocao("teste", true, 3, 10),
                new Promocao("teste2", false, 2, 1)
            };
        }
    }
}
