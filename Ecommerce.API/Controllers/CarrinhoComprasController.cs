using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Ecommerce.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("carrinhoCompras")]
    public class CarrinhoComprasController
    {
        [HttpGet]
        public CarrinhoCompras RetornarCarrinhoCompras([FromServices] ICarrinhoRepository repository) 
        {
            return repository.retornarCarrinhoDeCompras();
        }

        [Route("adicionarProdutosNoCarrinho")]
        [HttpPut]
        public ResultModel AdicionarProdutoNoCarrinho([FromServices] CarrinhoService service, int idProduto, int quantidade)
        {
            return service.AdicionarProdutoNoCarrinho(idProduto, quantidade);
        }

        [Route("removerProdutosDoCarrinho")]
        [HttpPut]
        public ResultModel RemoverProdutoNoCarrinho([FromServices] CarrinhoService service, int idProduto, int quantidade)
        {
            return service.RemoverProdutoDoCarrinho(idProduto, quantidade);
        }

        [Route("limparCarrinhoDeCompras")]
        [HttpPut]
        public ResultModel LimparProdutoNoCarrinho([FromServices] CarrinhoService service)
        {
            return service.LimparProdutosDoCarrinho();
        }
    }
}
