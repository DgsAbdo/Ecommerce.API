using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ItemCarrinho
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public int Quantidade { get; set; }
        public int CarrinhoComprasId { get; set; }
        [JsonIgnore]
        public CarrinhoCompras? CarrinhoCompras { get; set; }
    }
}
