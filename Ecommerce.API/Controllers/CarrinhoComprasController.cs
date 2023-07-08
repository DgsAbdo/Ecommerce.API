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

        [Route("adicionarProdutoNoCarrinho")]
        [HttpPut]
        public ResultModel AdicionarProdutoNoCarrinho([FromServices] CarrinhoService service, int idProduto)
        {
            return service.AdicionarProdutoNoCarrinho(idProduto);
        }

    }
}
