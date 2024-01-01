using Microsoft.AspNetCore.Mvc;
using WebProgramlama.Models;
using WebProgramlama.Services;

namespace WebProgramlama.Controllers
{
    public class RandevuController : Controller
    {
        private readonly RandevuService _randevuService;

        public RandevuController(RandevuService randevuService)
        {
            _randevuService = randevuService;
        }

        public IActionResult Index()
        {
            var randevular = _randevuService.GetAllRandevular();
            return View(randevular);
        }

        public IActionResult Details(int id)
        {
            var randevu = _randevuService.GetRandevu(id);
            return View(randevu);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _randevuService.CreateRandevu(randevu);
                return RedirectToAction("Index");
            }
            return View(randevu);
        }

        public IActionResult Edit(int id)
        {
            var randevu = _randevuService.GetRandevu(id);
            return View(randevu);
        }

        [HttpPost]
        public IActionResult Edit(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _randevuService.UpdateRandevu(randevu);
                return RedirectToAction("Index");
            }
            return View(randevu);
        }

        public IActionResult Delete(int id)
        {
            var randevu = _randevuService.GetRandevu(id);
            return View(randevu);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _randevuService.DeleteRandevu(id);
            return RedirectToAction("Index");
        }
    }
}
