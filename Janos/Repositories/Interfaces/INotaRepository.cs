using Janos.Models;

namespace Janos.Repositories.Interfaces
{
    public interface INotaRepository
    {
        Nota GetById(int id);
        IEnumerable<Nota> GetAll();
        void Add(Nota nota);
        void Update(Nota nota);
        void Delete(int id);
    }
}
