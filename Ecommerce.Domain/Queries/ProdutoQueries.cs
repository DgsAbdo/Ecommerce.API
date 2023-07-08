using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
