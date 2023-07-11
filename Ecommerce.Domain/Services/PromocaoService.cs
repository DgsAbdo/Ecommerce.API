using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Domain.Services
{
    public class PromocaoService
    {
        private readonly IPromocaoRepository _repository;

        public PromocaoService(IPromocaoRepository repository) 
        {
            _repository = repository;
        }

        public ResultModel CriarPromocao(PromocaoModel promocaoModel)
        {
            if (!promocaoModel.ValidarPromocao())
                return new ResultModel(false, "Informacoes de promocao nao validas", promocaoModel);

            var promocaoEntity = new Promocao(promocaoModel.Nome, promocaoModel.PromocaoComValorFixo, 
                promocaoModel.QuantidadeProdutos, promocaoModel.Valor);

            _repository.Criar(promocaoEntity);

            return new ResultModel(true, "Promocao criada.", promocaoEntity);
        }

        public ResultModel ModificarPromocao(PromocaoUpdateModel promocao)
        {
            if (!promocao.ValidarAtualizacaoPromocao())
                return new ResultModel(false, "Informacoes de promocao nao validas", promocao);

            var promocaoEntity = new Promocao(promocao.Id, promocao.Nome, promocao.PromocaoComValorFixo, 
                promocao.QuantidadeProdutos, promocao.Valor);

            _repository.Atualizar(promocaoEntity);

            return new ResultModel(true, "Promocao atualizada.", promocaoEntity);
        }

        public ResultModel DeletarPromocao(int id)
        {
            if(id == 0)
                return new ResultModel(false, "Id invalido.", id);

            _repository.Deletar(id);

            return new ResultModel(true, "Promocao deletada com sucesso.", id);
        }
    }
}
