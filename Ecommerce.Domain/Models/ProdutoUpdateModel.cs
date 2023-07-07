using Ecommerce.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public  class ProdutoUpdateModel : ProdutoModel
    {
        public ProdutoUpdateModel(int id, string nome, double preco, int promocaoId) : base(nome, preco, promocaoId)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            PromocaoId = promocaoId;
        }

        public int Id { get; set; }

        public bool ValidarAtualizacaoProduto()
        {
            if (!string.IsNullOrEmpty(Nome) && Preco != 0 && Id != 0)
                return true;

            return false;
        }
    }
}
