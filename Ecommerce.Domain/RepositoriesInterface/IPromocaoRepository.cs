using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories
{
    public interface IPromocaoRepository
    {
        void Criar(Promocao produto);
        void Atualizar(Promocao produto);
        Promocao PegarPorId(int id);
        IEnumerable<Promocao> PegarTodasPromocoes();
        void Deletar(int id);
    }
}
