using Janos.Data;
using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Janos.Repositories
{
    public class LojaRepository : ILojaRepository
    {
        private readonly AppDbContext _context;

        public LojaRepository(AppDbContext context)
        {
            _context = context;
        }

        public Loja GetById(int id)
        {
            return _context.Lojas.Include(l => l.Endereco).Include(l => l.Notas).FirstOrDefault(l => l.LojaId == id);
        }

        public IEnumerable<Loja> GetAll()
        {
            return _context.Lojas.Include(l => l.Endereco).Include(l => l.Notas).ToList();
        }

            public IEnumerable<Loja> GetByNotaMinima(int notaMinima) // Novo método
    {
        return _context.Lojas
            .Include(l => l.Endereco)
            .Include(l => l.Notas)
            .Where(l => l.Notas.Any(n => n.Valor >= notaMinima)) 
            .ToList();
    }

        public void Add(Loja loja)
        {
            _context.Lojas.Add(loja);
            _context.SaveChanges();
        }

        public void Update(Loja loja)
        {
            _context.Lojas.Update(loja);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var loja = _context.Lojas.Find(id);
            if (loja != null)
            {
                _context.Lojas.Remove(loja);
                _context.SaveChanges();
            }
        }
    }
}
