using Janos.Models;

namespace Janos.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Endereco GetById(int id);
        IEnumerable<Endereco> GetAll();
        void Add(Endereco endereco);
        void Update(Endereco endereco);
        void Delete(int id);
    }
}
