using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Commands;
using System.Security.Cryptography.X509Certificates;
using Ecommerce.Domain.Handlers;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("Produtos")]
    public class ProdutosController : ControllerBase
    {
        //[Route("")]
        //[HttpGet]
        //public IEnumerable<Produto> GetAll(
        //    [FromServices] ITodoRepository repository
        //)
        //{
        //    var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //    return repository.GetAll(user);
        //}

        private ProdutoHandler handler;

        [HttpPost]
        public CommandResult CriarProduto([FromBody] ProdutoCommand command)
        {
            handler = new ProdutoHandler();
            return handler.CriarProduto(command);
        }
    }
}

