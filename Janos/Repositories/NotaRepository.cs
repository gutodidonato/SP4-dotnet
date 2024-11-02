using Janos.Data;
using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Janos.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly AppDbContext _context;

        public NotaRepository(AppDbContext context)
        {
            _context = context;
        }

        public Nota GetById(int id)
        {
            return _context.Notas.Find(id);
        }

        public IEnumerable<Nota> GetAll()
        {
            return _context.Notas.ToList();
        }

        public void Add(Nota nota)
        {
            _context.Notas.Add(nota);
            _context.SaveChanges();
        }

        public void Update(Nota nota)
        {
            _context.Notas.Update(nota);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var nota = _context.Notas.Find(id);
            if (nota != null)
            {
                _context.Notas.Remove(nota);
                _context.SaveChanges();
            }
        }
    }
}
