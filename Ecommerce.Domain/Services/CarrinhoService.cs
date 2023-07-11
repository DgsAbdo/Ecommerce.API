using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Domain.Services
{
    public class CarrinhoService
    {
        private readonly ICarrinhoRepository _repositoryCarrinho;
        private readonly IProdutoRepository _repositoryProduto;

        public CarrinhoService (ICarrinhoRepository repository, IProdutoRepository produtoRepository)
        {
            _repositoryCarrinho = repository;
            _repositoryProduto = produtoRepository;
        }

        public ResultModel AdicionarProdutoNoCarrinho(int idProduto, int quantidade)
        {
            if(idProduto == 0)
                return new ResultModel(false, "Id do produto invalido.", idProduto);

            var produto = _repositoryProduto.PegarPorId(idProduto);

            if (produto == null)
                return new ResultModel(false, "Produto nao cadastrado.", 0);

            try
            {
                CarrinhoCompras carrinho = _repositoryCarrinho.retornarCarrinhoDeCompras();
                carrinho = VerificarItemEAdicionarDoCarrinho(produto, quantidade, carrinho);
                carrinho.ValorTotal = CalcularValorTotalCarrinho(carrinho);
                _repositoryCarrinho.AtualizarCarrinhoCompras(carrinho);

                return new ResultModel(true, $"{quantidade}x {produto.Nome} - Adicionado ao carrinho com sucesso.", carrinho);

            }catch(Exception ex) 
            {
                return new ResultModel(false, ex.Message, ex);
            }
        }

        public ResultModel RemoverProdutoDoCarrinho(int idProduto, int quantidade)
        {
            try
            {
                CarrinhoCompras carrinho = _repositoryCarrinho.retornarCarrinhoDeCompras();
                RemoverItemDoCarrinho(quantidade, idProduto, carrinho);
                carrinho.ValorTotal = CalcularValorTotalCarrinho(carrinho);
                _repositoryCarrinho.AtualizarCarrinhoCompras(carrinho);
                return new ResultModel(true, $"Item removido do carrinho.", carrinho);
            }
            catch(Exception ex) 
            {
                return new ResultModel(false, ex.Message, ex);
            }
        }

        public ResultModel LimparProdutosDoCarrinho()
        {
            try
            {
                var carrinho = _repositoryCarrinho.retornarCarrinhoDeCompras();
                if (carrinho.ItensCarrinho == null)
                    return new ResultModel(false, "Carrinho não possui itens.", carrinho);
                else
                {
                    carrinho.ItensCarrinho.Clear();
                    carrinho.ValorTotal = 0;
                    _repositoryCarrinho.AtualizarCarrinhoCompras(carrinho);
                    return new ResultModel(true, "Carrinho limpo com sucesso", carrinho);
                }

            }
            catch(Exception ex)
            {
                return new ResultModel(false, ex.Message, ex);
            }
        }

        private CarrinhoCompras VerificarItemEAdicionarDoCarrinho(Produto produto, int quantidade, CarrinhoCompras carrinho)
        {
            ItemCarrinho itemExistente = carrinho.ItensCarrinho.FirstOrDefault(i => i.ProdutoId == produto.Id);

            if (itemExistente != null)
                carrinho.ItensCarrinho.First(i => i.ProdutoId == produto.Id).Quantidade += quantidade;
            else
            {
                ItemCarrinho novoItem = new ItemCarrinho
                {
                    CarrinhoComprasId = carrinho.Id,
                    ProdutoId = produto.Id,
                    Quantidade = quantidade,
                    Produto = produto
                };

                carrinho.ItensCarrinho.Add(novoItem);
            }

            return carrinho;
        }

        private CarrinhoCompras RemoverItemDoCarrinho(int quantidade, int produtoId, CarrinhoCompras carrinho)
        {
            var itemCarrinho = carrinho.ItensCarrinho.FirstOrDefault(i => i.ProdutoId == produtoId);

            if (itemCarrinho != null)
            {
                itemCarrinho.Quantidade -= quantidade;

                if (itemCarrinho.Quantidade <= 0)
                    carrinho.ItensCarrinho.Remove(itemCarrinho);
                else
                    carrinho.ItensCarrinho.FirstOrDefault(i => i.ProdutoId == produtoId).Quantidade = itemCarrinho.Quantidade;
            }

            return carrinho;
        }

        #region Metodos para calcular o valor total do carrinho
        private double CalcularValorTotalCarrinho(CarrinhoCompras carrinho)
        {
            double valorTotal = 0;

            foreach (var item in carrinho.ItensCarrinho)
            {
                double valorItem = CalcularValorItem(item);
                valorTotal += valorItem;
            }

            return valorTotal;
        }

        private double CalcularValorItem(ItemCarrinho item)
        {
            Produto produto = item.Produto;
            Promocao promocao = produto.Promocao;

            double valorItem = 0;

            if (promocao != null)
            {
                if (promocao.PromocaoComValorFixo)
                {
                    valorItem = CalcularValorItemPromocaoValorFixo(item, promocao);
                }
                else
                {
                    valorItem = CalcularValorItemPromocaoValorNaoFixo(item, promocao);
                }
            }
            else
            {
                valorItem = produto.Preco * item.Quantidade;
            }

            return valorItem;
        }

        private double CalcularValorItemPromocaoValorFixo(ItemCarrinho item, Promocao promocao)
        {
            int quantidadePromocional = promocao.Quantidade;
            int quantidadePromocoesAplicadas = item.Quantidade / quantidadePromocional;
            int quantidadeProdutosSemPromocao = item.Quantidade % quantidadePromocional;

            double valorItem = (quantidadePromocoesAplicadas * promocao.Valor) + (quantidadeProdutosSemPromocao * item.Produto.Preco);

            return valorItem;
        }

        private double CalcularValorItemPromocaoValorNaoFixo(ItemCarrinho item, Promocao promocao)
        {
            int quantidadePromocional = promocao.Quantidade;
            int quantidadePromocoesAplicadas = item.Quantidade / (quantidadePromocional + 1);
            int quantidadeProdutosSemPromocao = item.Quantidade % (quantidadePromocional + 1);

            double valorItem = (quantidadePromocoesAplicadas * (promocao.Valor * quantidadePromocional)) + 
                (quantidadeProdutosSemPromocao * item.Produto.Preco);

            return valorItem;
        }
        #endregion  
    }
}
