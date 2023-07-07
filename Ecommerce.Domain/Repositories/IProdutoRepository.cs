using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories
{
    public interface IProdutoRepository
    {
        void Criar(Produto produto);
        void Atualizar(Produto produto);
        Produto PegarPorId(int id);
        IEnumerable<Produto> PegarTodos();
        IEnumerable<Produto> PegarTodosComPromocao();
        void Deletar(int id);
    }
}
