using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Commands
{
    public class ProdutoCommand
    {
        public ProdutoCommand() 
        {
            
        }

        public ProdutoCommand(string nome, double preco, int promocaoId)
        {
            Nome= nome;
            Preco= preco;
            PromocaoId = promocaoId;
        }

        public string Nome { get; set; }
        public double Preco { get; set; }
        public int PromocaoId { get; set; }

    }
}
