using Janos.Data;
using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Janos.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Endereco GetById(int id)
        {
            return _context.Enderecos.Find(id);
        }

        public IEnumerable<Endereco> GetAll()
        {
            return _context.Enderecos.ToList();
        }

        public void Add(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public void Update(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var endereco = _context.Enderecos.Find(id);
            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                _context.SaveChanges();
            }
        }
    }
}
