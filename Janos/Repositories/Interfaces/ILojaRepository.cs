using Janos.Models;

namespace Janos.Repositories.Interfaces
{
    public interface ILojaRepository
    {
        Loja GetById(int id);
        IEnumerable<Loja> GetAll();
         IEnumerable<Loja> GetByNotaMinima(int notaMinima);
        void Add(Loja loja);
        void Update(Loja loja);
        void Delete(int id);
    }
}