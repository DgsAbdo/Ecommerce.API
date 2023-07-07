﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool PromocaoComValorFixo { get; set; }
        public int QuantidadeProdutos { get; set; }
        public double Valor { get; set; }
    }
}
