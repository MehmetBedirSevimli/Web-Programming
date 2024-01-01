using WebProgramlama.Data.Repositories;
using WebProgramlama.Models;

namespace WebProgramlama.Services
{
    public class AnaBilimDaliService
    {
        private readonly AnaBilimDaliRepository _anaBilimDaliRepository;

        public AnaBilimDaliService(AnaBilimDaliRepository anaBilimDaliRepository)
        {
            _anaBilimDaliRepository = anaBilimDaliRepository;
        }

        public IEnumerable<AnaBilimDali> GetAllAnaBilimDallari()
        {
            return _anaBilimDaliRepository.GetAll();
        }

        public AnaBilimDali GetAnaBilimDaliById(int id)
        {
            return _anaBilimDaliRepository.GetById(id);
        }

        public void AddAnaBilimDali(AnaBilimDali anaBilimDali)
        {
            _anaBilimDaliRepository.Add(anaBilimDali);
        }

        public void UpdateAnaBilimDali(AnaBilimDali anaBilimDali)
        {
            _anaBilimDaliRepository.Update(anaBilimDali);
        }

        public void DeleteAnaBilimDali(int id)
        {
            _anaBilimDaliRepository.Delete(id);
        }
    }

}
