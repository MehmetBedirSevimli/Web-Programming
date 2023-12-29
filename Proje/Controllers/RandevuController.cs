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
        public async Task<IActionResult> Create([Bind("RandevuId,KullaniciId,DoktorId,Tarih,Durum")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
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

        private bool RandevuExists(int id)
        {
            return _context.Randevular.Any(e => e.RandevuId == id);
        }
    }
}
