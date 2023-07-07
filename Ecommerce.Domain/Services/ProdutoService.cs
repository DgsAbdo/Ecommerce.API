using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public ResultModel CriarProduto(ProdutoModel produto)
        {
            if (!produto.ValidarProduto())
                return new ResultModel(false, "Informacoes de produto nao validas", produto);

            var produtoEntity = new Produto(produto.Nome, produto.Preco, produto.PromocaoId);

            _repository.Criar(produtoEntity);

            return new ResultModel(true, "Produto criado.", produtoEntity);
        }

        public ResultModel ModificarProduto(ProdutoUpdateModel produto)
        {
            if(!produto.ValidarAtualizacaoProduto())
                return new ResultModel(false, "Informacoes de produto nao validas", produto);

            var produtoEntity = new Produto(produto.Id,produto.Nome, produto.Preco, produto.PromocaoId);

            _repository.Atualizar(produtoEntity);

            return new ResultModel(true, "Produto atualizado.", produtoEntity);
        }
    }
}
