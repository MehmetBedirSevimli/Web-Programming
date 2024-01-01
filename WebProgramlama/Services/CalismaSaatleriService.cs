using System.Collections.Generic;
using WebProgramlama.Models;
using WebProgramlama.Data.Repositories;

namespace WebProgramlama.Services
{
    public class CalismaSaatleriService : ICalismaSaatleriService
    {
        private readonly ICalismaSaatleriRepository _calismaSaatleriRepository;

        public CalismaSaatleriService(ICalismaSaatleriRepository calismaSaatleriRepository)
        {
            _calismaSaatleriRepository = calismaSaatleriRepository;
        }

        public IEnumerable<CalismaSaatleri> GetAllCalismaSaatleri()
        {
            return _calismaSaatleriRepository.GetAll();
        }

        public CalismaSaatleri GetCalismaSaatleriById(int id)
        {
            return _calismaSaatleriRepository.GetById(id);
        }

        public void AddCalismaSaatleri(CalismaSaatleri calismaSaatleri)
        {
            _calismaSaatleriRepository.Add(calismaSaatleri);
        }

        public void UpdateCalismaSaatleri(CalismaSaatleri calismaSaatleri)
        {
            _calismaSaatleriRepository.Update(calismaSaatleri);
        }

        public void DeleteCalismaSaatleri(int id)
        {
            _calismaSaatleriRepository.Delete(id);
        }
    }
}
