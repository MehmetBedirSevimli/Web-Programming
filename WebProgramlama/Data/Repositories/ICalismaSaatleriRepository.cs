using System.Collections.Generic;
using WebProgramlama.Models;

namespace WebProgramlama.Data.Repositories
{
    public interface ICalismaSaatleriRepository
    {
        IEnumerable<CalismaSaatleri> GetAll();

        CalismaSaatleri GetById(int id);

        void Add(CalismaSaatleri entity);

        void Update(CalismaSaatleri entity);

        void Delete(int id);
    }
}
