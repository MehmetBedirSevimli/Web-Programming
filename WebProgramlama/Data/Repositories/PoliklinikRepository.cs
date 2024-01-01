using WebProgramlama.Models;

namespace WebProgramlama.Data.Repositories
{
    public class PoliklinikRepository
    {
        private readonly AppDbContext _context;

        public PoliklinikRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Poliklinik> GetAll()
        {
            return _context.Poliklinikler.ToList();
        }

        public Poliklinik GetById(int id)
        {
            return _context.Poliklinikler.Find(id);
        }

        public void Add(Poliklinik poliklinik)
        {
            _context.Poliklinikler.Add(poliklinik);
            _context.SaveChanges();
        }

        public void Update(Poliklinik poliklinik)
        {
            _context.Poliklinikler.Update(poliklinik);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var poliklinik = _context.Poliklinikler.Find(id);
            if (poliklinik != null)
            {
                _context.Poliklinikler.Remove(poliklinik);
                _context.SaveChanges();
            }
        }
    }

}
