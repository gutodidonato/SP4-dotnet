using Janos.Models;

namespace Janos.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Item GetById(string nome);
        IEnumerable<Item> GetAll();
        void Add(Item item);
        void Update(Item item);
        void Delete(string nome);
    }
}
