using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Promocao
    {
        public int PromocaoId { get; set; }
        public string NomePromocao { get; set; }
        public bool ValorFixo { get; set; }
        public int QuantidadeProdutos { get; set; }
        public string Valor { get; set; }
    }
}
