using Ecommerce.Domain.Entities;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Queries
{
    public static class ProdutoQueries
    {
        public static Expression<Func<Produto, bool>> PegarProdutoPorID(int id)
        {
            return x => (x.Id == id);
        }

        public static Expression<Func<Produto, bool>> PegarProdutoPorNome(string nome)
        {
            return x => x.Nome.ToLower() == nome.ToLower();
        }

        public static Expression<Func<Produto, bool>> PegarProdutoPorPromocao(int idPromocao)
        {
            return x => x.PromocaoId == idPromocao;
        }

        public static Expression<Func<Produto, bool>> PegarProdutoComPromocao()
        {
            return x => x.Promocao != null ;
        }
    }
}
