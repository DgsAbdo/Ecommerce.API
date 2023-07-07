using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Commands
{
    public class PromocaoModel
    {
        public PromocaoModel(int idPromocao, string nome, bool promocaoComValorFixo, int quantidadeProdutos, double valor)
        {
            Id = idPromocao;
            Nome = nome;
            PromocaoComValorFixo = promocaoComValorFixo;
            QuantidadeProdutos = quantidadeProdutos;
            Valor = valor;
        }

        public PromocaoModel(string nome, bool promocaoComValorFixo, int quantidadeProdutos, double valor) 
        {
            Nome= nome;
            PromocaoComValorFixo= promocaoComValorFixo;
            QuantidadeProdutos= quantidadeProdutos;
            Valor= valor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool PromocaoComValorFixo { get; set; }
        public int QuantidadeProdutos { get; set; }
        public double Valor { get; set; }
    }
}
