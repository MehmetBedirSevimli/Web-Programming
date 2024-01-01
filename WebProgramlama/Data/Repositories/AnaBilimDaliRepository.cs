using WebProgramlama.Models;

namespace WebProgramlama.Data.Repositories
{
    public class AnaBilimDaliRepository
    {
        private readonly AppDbContext _context;

        public AnaBilimDaliRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AnaBilimDali> GetAll()
        {
            return _context.AnaBilimDallari.ToList();
        }

        public AnaBilimDali GetById(int id)
        {
            return _context.AnaBilimDallari.Find(id);
        }

        public void Add(AnaBilimDali anaBilimDali)
        {
            _context.AnaBilimDallari.Add(anaBilimDali);
            _context.SaveChanges();
        }

        public void Update(AnaBilimDali anaBilimDali)
        {
            _context.AnaBilimDallari.Update(anaBilimDali);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var anaBilimDali = _context.AnaBilimDallari.Find(id);
            if (anaBilimDali != null)
            {
                _context.AnaBilimDallari.Remove(anaBilimDali);
                _context.SaveChanges();
            }
        }
    }

}
