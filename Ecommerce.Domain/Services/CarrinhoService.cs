using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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
                return new ResultModel(false, "Id invalido.", idProduto);

            var produto = _repositoryProduto.PegarPorId(idProduto);

            if (produto == null)
                return new ResultModel(false, "Produto nao cadastrado.", 0);

            try
            {
                AdicionarItensCarrinho(produto, quantidade);

                return new ResultModel(true, "Produto adicionado ao carrinho.", produto);

            }catch(Exception ex) 
            {
                return new ResultModel(false, ex.Message, ex);
            }
        }

        public ResultModel RemoverProdutoDoCarrinho(int idProduto, int quantidade)
        {
            return null;
        }

        public ResultModel LimparProdutosDoCarrinho()
        {
            try
            {
                _repositoryCarrinho.LimparCarrinho();
                return new ResultModel(true, "Carrinho limpo com sucesso", null);

            }
            catch(Exception ex)
            {
                return new ResultModel(false, ex.Message, ex);
            }
        }

        #region Metodos Privados
        private void AdicionarItensCarrinho(Produto produto, int quantidade)
        {
            CarrinhoCompras carrinho = _repositoryCarrinho.retornarCarrinhoDeCompras();
            carrinho = VerificarItemEAdicionarNoCarrinho(produto, quantidade, carrinho);
            carrinho.ValorTotal = CalcularValorTotalCarrinho(carrinho);
            _repositoryCarrinho.AtualizarCarrinhoCompras(carrinho);
        }

        private CarrinhoCompras VerificarItemEAdicionarNoCarrinho(Produto produto, int quantidade, CarrinhoCompras carrinho)
        {
            //implementar logica de itemExistente
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

        //private double CalcularValorTotalCarrinho(CarrinhoCompras carrinho)
        //{
        //    double valorTotal = 0;

        //    foreach (var item in carrinho.ItensCarrinho)
        //    {
        //        Produto produto = item.Produto;
        //        Promocao promocao = produto.Promocao;

        //        double valorItem = 0;

        //        if (promocao != null)
        //        {
        //            if (promocao.PromocaoComValorFixo)
        //            {
        //                int quantidadePromocional = promocao.Quantidade;
        //                int quantidadePromocoesAplicadas = item.Quantidade / quantidadePromocional;
        //                int quantidadeProdutosSemPromocao = item.Quantidade % quantidadePromocional;

        //                valorItem = (quantidadePromocoesAplicadas * promocao.Valor) + (quantidadeProdutosSemPromocao * produto.Preco);
        //            }
        //            else
        //            {
        //                int quantidadePromocional = promocao.Quantidade;
        //                int quantidadePromocoesAplicadas = item.Quantidade / (quantidadePromocional + 1);
        //                int quantidadeProdutosSemPromocao = item.Quantidade % (quantidadePromocional + 1);

        //                valorItem = (quantidadePromocoesAplicadas * (promocao.Valor * quantidadePromocional)) + (quantidadeProdutosSemPromocao * produto.Preco);
        //            }
        //        }
        //        else
        //        {
        //            valorItem = produto.Preco * item.Quantidade;
        //        }

        //        valorTotal += valorItem;
        //    }

        //    return valorTotal;
        //}
        #endregion
    }
}
