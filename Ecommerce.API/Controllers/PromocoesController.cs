using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("promocoes")]
    public class PromocoesController: ControllerBase
    {
        [HttpGet]
        [Route("obterTodasPromocoes")]
        public IEnumerable<Promocao> BuscarTodosProdutos([FromServices] IPromocaoRepository repository)
        {
            return repository.PegarTodasPromocoes();
        }

        [HttpGet]
        [Route("obterPromocaoPorId")]
        public Promocao BuscarProdutoPorId([FromServices] IPromocaoRepository repository, int id)
        {
            return repository.PegarPorId(id);
        }

        [HttpPost]
        [Route("criarPromocao")]
        public ResultModel CriarPromocao([FromServices] PromocaoService service, [FromBody] PromocaoModel promocao) 
        {
            return service.CriarPromocao(promocao);
        }

        [HttpPut]
        [Route("criarPromocao")]
        public ResultModel AtualizarPromocao([FromServices] PromocaoService service, [FromBody] PromocaoUpdateModel promocao)
        {
            return service.ModificarPromocao(promocao);
        }

        [HttpDelete]
        [Route("deletarPromocao")]
        public ResultModel CriarPromocao([FromServices] PromocaoService service, int id)
        {
            return service.DeletarPromocao(id);
        }
    }
}
