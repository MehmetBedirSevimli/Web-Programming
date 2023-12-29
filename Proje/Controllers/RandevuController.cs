using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Data;
using Proje.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Controllers
{
    /*
     * RandevuController sınıfının temel CRUD (Create, Read, Update, Delete) işlemlerini içermektedir. 
     * Ayrıca, Create aksiyonunda kullanıcıları ve doktorları 
     * dropdown listelerle göndermek için ViewBag kullanılmıştır.
     * */
    public class RandevuController : Controller
    {
        private readonly AppDbContext _context;

        public RandevuController(AppDbContext context)
        {
            _context = context;
        }

        // Randevu listesini görüntüleme
        public async Task<IActionResult> Index()
        {
            var randevular = await _context.Randevular
                .Include(r => r.Kullanici)
                .Include(r => r.Doktor)
                .ToListAsync();

            return View(randevular);
        }

        // Randevu oluşturma sayfasını görüntüleme
        public IActionResult Create()
        {
            // Gerekirse kullanıcıları ve doktorları dropdown listelerle gönderme
            ViewBag.KullaniciList = _context.Kullanicilar.ToList();
            ViewBag.DoktorList = _context.Doktorlar.ToList();

            return View();
        }

        // Randevu oluşturma
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*[ValidateAntiForgeryToken] özelliği, anti-forgery token'ın kontrol edilmesini sağlar, 
         * bu da sayfaya sadece sunucu tarafından oluşturulan formların 
         * gönderilebileceği anlamına gelir.
         * */
        public async Task<IActionResult> Create([Bind("RandevuId,KullaniciId,DoktorId,Tarih,Durum")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                // Aynı doktor ve tarih için başka bir randevu var mı kontrol et
                var existingAppointment = await _context.Randevular
                    .Where(r => r.DoktorId == randevu.DoktorId && r.Tarih == randevu.Tarih)
                    .FirstOrDefaultAsync();

                if (existingAppointment != null)
                {
                    // Aynı saatte başka bir randevu varsa kullanıcıya uygun bir mesaj gönder
                    ModelState.AddModelError(string.Empty, "Seçtiğiniz doktordan aynı saatte başka bir randevu mevcut.");
                    ViewBag.KullaniciList = _context.Kullanicilar.ToList();
                    ViewBag.DoktorList = _context.Doktorlar.ToList();
                    return View(randevu);
                }

                // Aynı saatte başka bir randevu yoksa işlemi devam ettir
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Gerekirse kullanıcıları ve doktorları dropdown listelerle gönderme
            ViewBag.KullaniciList = _context.Kullanicilar.ToList();
            ViewBag.DoktorList = _context.Doktorlar.ToList();

            return View(randevu);
        }

        // Randevu detaylarını görüntüleme
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(r => r.Kullanici)
                .Include(r => r.Doktor)
                .FirstOrDefaultAsync(m => m.RandevuId == id);

            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // Diğer gerekli aksiyonlar...
        public IActionResult RandevuSec()
        {
            // Gerekirse klinik ve doktor verilerini view'a gönderme
            ViewBag.Klinikler = _context.Poliklinikler.ToList();
            ViewBag.Doktorlar = _context.Doktorlar.ToList();

            return View();
        }

        /*
         * Bu action, belirtilen id değerine sahip randevuyu veritabanından siler.
         * RandevuListe.cshtml sayfasındaki form, 
         * bu action'ı çağırarak randevuyu iptal etme işlemini gerçekleştirir.
         * */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RandevuIptal(int id)
        {
            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }

            _context.Randevular.Remove(randevu);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        //Bu metot, veritabanında belirli bir Randevu ID'sine sahip bir randevu kaydının var olup olmadığını kontrol eder.
        private bool RandevuExists(int id)
        {
            return _context.Randevular.Any(e => e.RandevuId == id);
        }
    }
}
