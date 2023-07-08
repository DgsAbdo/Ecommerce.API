﻿using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface ICarrinhoRepository
    {
        public void AdicionarProdutoNoCarrinho(Produto produto);
        public CarrinhoCompras retornarCarrinhoDeCompras();

    }
}
