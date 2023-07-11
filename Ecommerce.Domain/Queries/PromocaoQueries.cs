using Ecommerce.Domain.Entities;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Queries
{
    public  class PromocaoQueries
    {
        public static Expression<Func<Promocao, bool>> PegarPromocaoPorID(int id)
        {
            return x => (x.Id == id);
        }
    }
}
