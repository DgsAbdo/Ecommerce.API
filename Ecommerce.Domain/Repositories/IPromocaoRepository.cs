using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface IPromocaoRepository
    {
        void Criar(Promocao produto);
        void Atualizar(Promocao produto);
        Promocao PegarPorId(int id);
        IEnumerable<Promocao> PegarTodasPromocoes();
        void Deletar(int id);
    }
}
