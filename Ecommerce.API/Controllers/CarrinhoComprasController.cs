using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("CarrinhoCompras")]
    [Authorize]
    public class CarrinhoComprasController
    {
        //[Route("")]
        //[HttpGet]
        //public IEnumerable<TodoItem> GetAll(
        //    [FromServices] ITodoRepository repository
        //)
        //{
        //    var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //    return repository.GetAll(user);
        //}

    }
}
