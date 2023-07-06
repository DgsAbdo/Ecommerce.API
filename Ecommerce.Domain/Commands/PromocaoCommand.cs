using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Commands
{
    public class PromocaoCommand
    {
        public string NomePromocao { get; set; }
        public bool ValorFixo { get; set; }
        public int QuantidadeProdutos { get; set; }
        public string Valor { get; set; }
    }
}
