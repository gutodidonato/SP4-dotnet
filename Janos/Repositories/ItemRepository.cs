using Janos.Data;
using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Janos.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public Item GetById(string nome)
        {
            return _context.Itens.FirstOrDefault(i => i.Nome == nome);
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Itens.ToList();
        }

        public void Add(Item item)
        {
            _context.Itens.Add(item);
            _context.SaveChanges();
        }

        public void Update(Item item)
        {
            _context.Itens.Update(item);
            _context.SaveChanges();
        }

        public void Delete(string nome)
        {
            var item = _context.Itens.FirstOrDefault(i => i.Nome == nome);
            if (item != null)
            {
                _context.Itens.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
