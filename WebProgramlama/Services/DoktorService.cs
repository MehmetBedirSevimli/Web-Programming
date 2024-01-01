using System.Collections.Generic;
using WebProgramlama.Data.Repositories;
using WebProgramlama.Models;

namespace WebProgramlama.Services
{
    public class DoktorService : IDoktorService
    {
        private readonly IDoktorRepository _doktorRepository;

        public DoktorService(IDoktorRepository doktorRepository)
        {
            _doktorRepository = doktorRepository;
        }

        public IEnumerable<Doktor> GetAllDoktorlar()
        {
            return _doktorRepository.GetAll();
        }

        public Doktor GetDoktorById(int id)
        {
            return _doktorRepository.GetById(id);
        }

        public void AddDoktor(Doktor doktor)
        {
            _doktorRepository.Add(doktor);
        }

        public void UpdateDoktor(Doktor doktor)
        {
            _doktorRepository.Update(doktor);
        }

        public void DeleteDoktor(int id)
        {
            _doktorRepository.Delete(id);
        }
    }
}
