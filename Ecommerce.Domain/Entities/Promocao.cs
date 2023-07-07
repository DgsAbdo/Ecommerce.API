using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Promocao
    {
        public Promocao(string nome, bool promocaoComValorFixo, int quantidadeProdutos, double valor) 
        {
            Nome= nome;
            PromocaoComValorFixo= promocaoComValorFixo;
            QuantidadeProdutos= quantidadeProdutos;
            Valor= valor;
        }

        public Promocao(int id, string nome, bool promocaoComValorFixo, int quantidadeProdutos, double valor)
        {
            Id= id;
            Nome = nome;
            PromocaoComValorFixo = promocaoComValorFixo;
            QuantidadeProdutos = quantidadeProdutos;
            Valor = valor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool PromocaoComValorFixo { get; set; }
        public int QuantidadeProdutos { get; set; }
        public double Valor { get; set; }

        [JsonIgnore]
        public List<Produto> Produtos { get; set; }
    }
}
