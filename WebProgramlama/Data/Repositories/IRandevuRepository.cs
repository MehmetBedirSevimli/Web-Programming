using System.Collections.Generic;
using WebProgramlama.Models;

namespace WebProgramlama.Data.Repositories
{
    public interface IRandevuRepository
    {
        IEnumerable<Randevu> GetRandevularByUserId(int userId);
        void Add(Randevu randevu);
        Randevu GetById(int id);
        void Update(Randevu randevu);
        void Delete(int id);
        IEnumerable<Randevu> GetAll();

        // Diğer işlemler...
    }
}
