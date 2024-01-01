using Microsoft.AspNetCore.Mvc;
using WebProgramlama.Models;
using WebProgramlama.Services;

public class CalismaSaatleriController : Controller
{
    private readonly ICalismaSaatleriService _calismaSaatleriService;

    public CalismaSaatleriController(ICalismaSaatleriService calismaSaatleriService)
    {
        _calismaSaatleriService = calismaSaatleriService;
    }

    // GET: CalismaSaatleri
    public IActionResult Index()
    {
        var calismaSaatleriList = _calismaSaatleriService.GetAllCalismaSaatleri();
        return View(calismaSaatleriList);
    }

    // GET: CalismaSaatleri/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CalismaSaatleri/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CalismaSaatleri calismaSaatleri)
    {
        if (ModelState.IsValid)
        {
            _calismaSaatleriService.AddCalismaSaatleri(calismaSaatleri);
            return RedirectToAction(nameof(Index));
        }
        return View(calismaSaatleri);
    }

    // GET: CalismaSaatleri/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var calismaSaatleri = _calismaSaatleriService.GetCalismaSaatleriById(id.Value);
        if (calismaSaatleri == null)
        {
            return NotFound();
        }

        return View(calismaSaatleri);
    }

    // POST: CalismaSaatleri/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, CalismaSaatleri calismaSaatleri)
    {
        if (id != calismaSaatleri.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _calismaSaatleriService.UpdateCalismaSaatleri(calismaSaatleri);
            return RedirectToAction(nameof(Index));
        }
        return View(calismaSaatleri);
    }

    // GET: CalismaSaatleri/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var calismaSaatleri = _calismaSaatleriService.GetCalismaSaatleriById(id.Value);
        if (calismaSaatleri == null)
        {
            return NotFound();
        }

        return View(calismaSaatleri);
    }

    // GET: CalismaSaatleri/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var calismaSaatleri = _calismaSaatleriService.GetCalismaSaatleriById(id.Value);
        if (calismaSaatleri == null)
        {
            return NotFound();
        }

        return View(calismaSaatleri);
    }

    // POST: CalismaSaatleri/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _calismaSaatleriService.DeleteCalismaSaatleri(id);
        return RedirectToAction(nameof(Index));
    }
}
