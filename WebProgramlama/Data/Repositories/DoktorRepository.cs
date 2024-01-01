using System.Collections.Generic;
using System.Linq;
using WebProgramlama.Models;

namespace WebProgramlama.Data.Repositories
{
    public class DoktorRepository : IDoktorRepository
    {
        private readonly AppDbContext _context;

        public DoktorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doktor> GetAll()
        {
            return _context.Doktorlar.ToList();
        }

        public Doktor GetById(int id)
        {
            return _context.Doktorlar.Find(id);
        }

        public void Add(Doktor entity)
        {
            _context.Doktorlar.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Doktor entity)
        {
            _context.Doktorlar.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var doktor = _context.Doktorlar.Find(id);
            if (doktor != null)
            {
                _context.Doktorlar.Remove(doktor);
                _context.SaveChanges();
            }
        }
    }
}
