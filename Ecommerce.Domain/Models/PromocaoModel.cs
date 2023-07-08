namespace Ecommerce.Domain.Commands
{
    public class PromocaoModel
    {
        public PromocaoModel(string nome, bool promocaoComValorFixo, int quantidadeProdutos, double valor) 
        {
            Nome= nome;
            PromocaoComValorFixo= promocaoComValorFixo;
            QuantidadeProdutos= quantidadeProdutos;
            Valor= valor;
        }

        public string Nome { get; set; }
        public bool PromocaoComValorFixo { get; set; }
        public int QuantidadeProdutos { get; set; }
        public double Valor { get; set; }

        public bool ValidarPromocao()
        {
            if(!string.IsNullOrEmpty(Nome) && QuantidadeProdutos != 0 && Valor != 0)
                return true;

            return false;
        }
    }
}
