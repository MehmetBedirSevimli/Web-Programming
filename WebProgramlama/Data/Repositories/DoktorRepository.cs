using WebProgramlama.Models;

namespace WebProgramlama.Data.Repositories
{
    public class DoktorRepository
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

        public void Add(Doktor doktor)
        {
            _context.Doktorlar.Add(doktor);
            _context.SaveChanges();
        }

        public void Update(Doktor doktor)
        {
            _context.Doktorlar.Update(doktor);
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
