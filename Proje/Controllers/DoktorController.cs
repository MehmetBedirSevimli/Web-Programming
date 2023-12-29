using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Data;
using Proje.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Controllers
{
    public class DoktorController : Controller
    {
        private readonly AppDbContext _context;

        public DoktorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            var doctors = await _context.Doktorlar
                .Include(d => d.Poliklinik)
                .Include(d => d.WorkingHours)
                .ToListAsync();

            return View(doctors);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            ViewBag.Poliklinikler = _context.Poliklinikler.ToList(); // Poliklinikleri ViewBag'e ekleyerek view'da kullanabilirsiniz.
            return View();
        }

        // POST: Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoktorId,Adi,Soyadi,PoliklinikId")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Poliklinikler = _context.Poliklinikler.ToList(); // Hata durumunda Poliklinikleri ViewBag'e ekleyerek view'da kullanabilirsiniz.
            return View(doktor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }

            ViewBag.Poliklinikler = _context.Poliklinikler.ToList(); // Poliklinikleri ViewBag'e ekleyerek view'da kullanabilirsiniz.
            return View(doktor);
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoktorId,Adi,Soyadi,PoliklinikId")] Doktor doktor)
        {
            if (id != doktor.DoktorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.DoktorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Poliklinikler = _context.Poliklinikler.ToList(); // Hata durumunda Poliklinikleri ViewBag'e ekleyerek view'da kullanabilirsiniz.
            return View(doktor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar
                .Include(d => d.Poliklinik)
                .FirstOrDefaultAsync(m => m.DoktorId == id);

            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doktor = await _context.Doktorlar.FindAsync(id);
            _context.Doktorlar.Remove(doktor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
            return _context.Doktorlar.Any(e => e.DoktorId == id);
        }
    }
}
