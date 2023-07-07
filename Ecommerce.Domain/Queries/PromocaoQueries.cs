using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
