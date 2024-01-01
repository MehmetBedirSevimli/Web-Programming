using System.Collections.Generic;
using WebProgramlama.Models;

namespace WebProgramlama.Data.Repositories
{
    public interface IDoktorRepository
    {
        IEnumerable<Doktor> GetAll();
        Doktor GetById(int id);
        void Add(Doktor entity);
        void Update(Doktor entity);
        void Delete(int id);
    }
}
