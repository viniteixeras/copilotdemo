using copilotdemo.Models;
using System.Collections.Generic;

namespace copilotdemo.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto GetById(int id);
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(int id);
        int GetNextId();
    }
}
