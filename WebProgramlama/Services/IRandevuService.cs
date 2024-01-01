// IRandevuService.cs

using System.Collections.Generic;
using WebProgramlama.Models;

namespace WebProgramlama.Services
{
    public interface IRandevuService
    {
        IEnumerable<Randevu> GetAllRandevular();
        Randevu GetRandevuById(int id);
        void CreateRandevu(Randevu randevu);
        void UpdateRandevu(Randevu randevu);
        void DeleteRandevu(int id);
        Randevu GetRandevu(int id);
    }
}
