using Ecommerce.Domain.Commands;

namespace Ecommerce.Domain.Models
{
    public class PromocaoUpdateModel: PromocaoModel
    {
        public PromocaoUpdateModel(int idPromocao, string nome, bool promocaoComValorFixo, int quantidadeProdutos, double valor): 
            base(nome, promocaoComValorFixo, quantidadeProdutos, valor)
        {
            Id = idPromocao;
            Nome = nome;
            PromocaoComValorFixo = promocaoComValorFixo;
            QuantidadeProdutos = quantidadeProdutos;
            Valor = valor;
        }

        public int Id { get; set; }

        public bool ValidarAtualizacaoPromocao()
        {
            if (!string.IsNullOrEmpty(Nome) && QuantidadeProdutos != 0 && Valor != 0 && Id != 0)
                return true;

            return false;
        }
    }
}
