using copilotdemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace copilotdemo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private static List<Produto> _produtos = new List<Produto>();
        private static int _nextId = 1;

        public IEnumerable<Produto> GetAll()
        {
            return _produtos;
        }

        public Produto GetById(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Produto produto)
        {
            produto.Id = _nextId++;
            _produtos.Add(produto);
        }

        public void Update(Produto produto)
        {
            var index = _produtos.FindIndex(p => p.Id == produto.Id);
            if (index != -1)
            {
                _produtos[index] = produto;
            }
        }

        public void Delete(int id)
        {
            var produto = GetById(id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
        }

        public int GetNextId()
        {
            return _nextId;
        }
    }
}
