using WebProgramlama.Models;

namespace WebProgramlama.Data.Repositories
{
    // Örnek olarak RandevuRepository
    public class RandevuRepository
    {
        private readonly AppDbContext _context;

        public RandevuRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Randevu randevu)
        {
            _context.Randevular.Add(randevu);
            _context.SaveChanges();
        }

        public Randevu Get(int id)
        {
            return _context.Randevular.Find(id);
        }

        public IEnumerable<Randevu> GetAll()
        {
            return _context.Randevular.ToList();
        }

        public void Update(Randevu randevu)
        {
            _context.Randevular.Update(randevu);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var randevu = _context.Randevular.Find(id);
            _context.Randevular.Remove(randevu);
            _context.SaveChanges();
        }

        public Randevu GetRandevuByDoktorAndTarih(int doktorId, DateTime tarih)
        {
            // Veritabanında belirli bir doktorun ve tarihin uygun olup olmadığını kontrol eden sorgu
            return _context.Randevular
                .FirstOrDefault(r => r.DoktorId == doktorId && r.Tarih == tarih);
        }
    }


}
