using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebProgramlama.Data;
using WebProgramlama.Data.Repositories;
using WebProgramlama.Models;

namespace WebProgramlama.Services
{
    public class RandevuService
    {
        private readonly RandevuRepository _randevuRepository;
        private readonly AppDbContext _context;
        private readonly AuthService _authService;


        public RandevuService(RandevuRepository randevuRepository, AuthService authService, AppDbContext appDbContext )
        {
            _randevuRepository = randevuRepository;
            _authService = authService;
            _context = appDbContext;
        }

        public void CreateRandevu(Randevu randevu)
        {
            // Gerekirse iş mantığı kurallarını burada uygula

            // Örnek iş mantığı: Aynı doktora aynı tarih aralığında başka bir randevu var mı kontrolü
            bool isAvailable = CheckIfTimeSlotIsAvailable(randevu.DoktorId, randevu.Tarih);

            if (!isAvailable)
            {
                // İlgili tarih ve doktora başka randevu olduğu için yeni randevu oluşturulamaz.
                throw new ApplicationException("Belirtilen tarih ve doktora başka bir randevu bulunmaktadır.");
            }

            // Gerekli iş mantığı kontrolünden geçtikten sonra randevu eklenir.
            _randevuRepository.Add(randevu);
        }

       
        private bool CheckIfTimeSlotIsAvailable(int doktorId, DateTime tarih)
        {
            var existingRandevu = _randevuRepository.GetRandevuByDoktorAndTarih(doktorId, tarih);
            return existingRandevu == null;
        }


       


        public Randevu GetRandevu(int id)
        {
            return _randevuRepository.Get(id);
        }

        public IEnumerable<Randevu> GetAllRandevular()
        {
            return _randevuRepository.GetAll();
        }

        public void UpdateRandevu(Randevu randevu)
        {
            // Gerekirse iş mantığı kurallarını burada uygula

            // Örnek iş mantığı: Randevu tarihi gelecekte bir tarihe mi güncelleniyor kontrolü
            if (randevu.Tarih < DateTime.Now)
            {
                throw new ApplicationException("Geçmiş tarihli randevular güncellenemez.");
            }

            // Daha fazla iş mantığı kontrolleri eklenebilir...

            // Gerekli iş mantığı kontrolünden geçtikten sonra randevu güncellenir.
            _randevuRepository.Update(randevu);
        }


        public void DeleteRandevu(int id)
        {
            // Gerekirse iş mantığı kurallarını burada uygula

            // Örnek iş mantığı: Silinecek randevu kullanıcının kaydı mı?
            var randevuToDelete = _randevuRepository.Get(id);
            if (randevuToDelete == null)
            {
                throw new ApplicationException("Silinecek randevu bulunamadı.");
            }

            // Örnek iş mantığı: Sadece kullanıcının kendi randevularını silebilmesi
            int currentlyLoggedInUserId = int.Parse(_authService.GetCurrentlyLoggedInUserId());

            if (randevuToDelete.UserId != currentlyLoggedInUserId)
            {
                throw new ApplicationException("Bu randevuyu silme izniniz yok.");
            }

            // Daha fazla iş mantığı kontrolleri eklenebilir...

            // Gerekli iş mantığı kontrolünden geçtikten sonra randevu silinir.
            _randevuRepository.Delete(id);
        }

    }
}
