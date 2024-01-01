using System.Collections.Generic;
using WebProgramlama.Models;

namespace WebProgramlama.Services
{
    public interface IDoktorService
    {
        IEnumerable<Doktor> GetAllDoktorlar();
        Doktor GetDoktorById(int id);
        void AddDoktor(Doktor doktor);
        void UpdateDoktor(Doktor doktor);
        void DeleteDoktor(int id);
    }
}
