namespace Ecommerce.Domain.Commands
{
    public class ProdutoModel
    {
        public ProdutoModel(string nome, double preco, int? promocaoId)
        {
            Nome= nome;
            Preco= preco;
            PromocaoId = promocaoId;
        }

        public string Nome { get; set; }
        public double Preco { get; set; }
        public int? PromocaoId { get; set; }

        public bool ValidarProduto()
        {
            if (!string.IsNullOrEmpty(Nome) && Preco != 0)
                return true;

            return false;
        }

    }
}
