using System.Collections.Generic;
using System.Linq;
using WebProgramlama.Models;

namespace WebProgramlama.Data.Repositories
{
    public class CalismaSaatleriRepository : ICalismaSaatleriRepository
    {
        private readonly AppDbContext _context;

        public CalismaSaatleriRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CalismaSaatleri> GetAll()
        {
            return _context.CalismaSaatleri.ToList();
        }

        public CalismaSaatleri GetById(int id)
        {
            return _context.CalismaSaatleri.Find(id);
        }

        public void Add(CalismaSaatleri entity)
        {
            _context.CalismaSaatleri.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CalismaSaatleri entity)
        {
            _context.CalismaSaatleri.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var calismaSaatleri = _context.CalismaSaatleri.Find(id);
            if (calismaSaatleri != null)
            {
                _context.CalismaSaatleri.Remove(calismaSaatleri);
                _context.SaveChanges();
            }
        }
    }
}
