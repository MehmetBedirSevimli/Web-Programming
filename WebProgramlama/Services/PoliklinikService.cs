using WebProgramlama.Data.Repositories;
using WebProgramlama.Models;

namespace WebProgramlama.Services
{
    public class PoliklinikService
    {
        private readonly PoliklinikRepository _poliklinikRepository;

        public PoliklinikService(PoliklinikRepository poliklinikRepository)
        {
            _poliklinikRepository = poliklinikRepository;
        }

        public IEnumerable<Poliklinik> GetAllPoliklinikler()
        {
            return _poliklinikRepository.GetAll();
        }

        public Poliklinik GetPoliklinikById(int id)
        {
            return _poliklinikRepository.GetById(id);
        }

        public void AddPoliklinik(Poliklinik poliklinik)
        {
            _poliklinikRepository.Add(poliklinik);
        }

        public void UpdatePoliklinik(Poliklinik poliklinik)
        {
            _poliklinikRepository.Update(poliklinik);
        }

        public void DeletePoliklinik(int id)
        {
            _poliklinikRepository.Delete(id);
        }
    }

}
