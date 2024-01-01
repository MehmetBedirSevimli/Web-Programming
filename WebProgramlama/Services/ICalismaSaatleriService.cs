using System.Collections.Generic;
using WebProgramlama.Models;

namespace WebProgramlama.Services
{
    public interface ICalismaSaatleriService
    {
        IEnumerable<CalismaSaatleri> GetAllCalismaSaatleri();

        CalismaSaatleri GetCalismaSaatleriById(int id);

        void AddCalismaSaatleri(CalismaSaatleri calismaSaatleri);

        void UpdateCalismaSaatleri(CalismaSaatleri calismaSaatleri);

        void DeleteCalismaSaatleri(int id);
    }
}
