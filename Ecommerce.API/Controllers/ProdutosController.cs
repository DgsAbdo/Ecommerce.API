using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Services;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Ecommerce.Domain.Models;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        [Route("obterTodosProdutos")]
        public IEnumerable<Produto> BuscarTodosProdutos([FromServices] IProdutoRepository repository)
        {
            return repository.PegarTodos();
        }

        [HttpGet]
        [Route("obterProdutoPorId")]
        public Produto BuscarProdutoPorId([FromServices] IProdutoRepository repository, int id)
        {
            return repository.PegarPorId(id);
        }

        //Modificar para trazer as informações de promocao junto
        [HttpGet]
        [Route("obterProdutosComPromocao")]
        public IEnumerable<Produto> BuscarProdutosComPromocao([FromServices] IProdutoRepository repository)
        {
            return repository.PegarTodosComPromocao();
        }

        [HttpPost]
        public ResultModel CriarProduto([FromBody] ProdutoModel model, [FromServices] ProdutoService handler)
        {
            return handler.CriarProduto(model);
        }

        [HttpPut]
        public ResultModel ModificarProduto([FromBody] ProdutoUpdateModel produtoModel, [FromServices] ProdutoService handler)
        {
            return handler.ModificarProduto(produtoModel);
        }
    }
}

