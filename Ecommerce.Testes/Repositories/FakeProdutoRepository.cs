using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Testes.Repositories
{
    internal class FakeProdutoRepository : IProdutoRepository
    {
        public void Atualizar(Produto produto)
        {

        }

        public void Criar(Produto produto)
        {

        }

        public void Deletar(int id)
        {

        }

        public Produto PegarPorId(int id)
        {
            return new Produto(1,"Teste", 10, 1);
        }

        public IEnumerable<Produto> PegarTodos()
        {
            return Enumerable.Empty<Produto>();
        }

        public IEnumerable<Produto> PegarTodosComPromocao()
        {
            return Enumerable.Empty<Produto>();
        }
    }
}
