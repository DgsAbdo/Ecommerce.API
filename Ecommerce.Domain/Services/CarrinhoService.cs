using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

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

        public ResultModel AdicionarProdutoNoCarrinho(int idProduto)
        {
            if(idProduto == 0)
                return new ResultModel(false, "Id invalido.", idProduto);

            var produto = _repositoryProduto.PegarPorId(idProduto);

            if (produto == null)
                return new ResultModel(false, "Produto não cadastrado.", produto);
            
            _repositoryCarrinho.AdicionarProdutoNoCarrinho(produto);

            return new ResultModel(true, "Produto adicionado ao carrinho.", idProduto);
        }

    }
}
