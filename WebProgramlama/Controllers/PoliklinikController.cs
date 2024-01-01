using Microsoft.AspNetCore.Mvc;
using WebProgramlama.Models;
using WebProgramlama.Services;

namespace WebProgramlama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliklinikController : ControllerBase
    {
        private readonly PoliklinikService _poliklinikService;

        public PoliklinikController(PoliklinikService poliklinikService)
        {
            _poliklinikService = poliklinikService;
        }

        [HttpGet]
        public IActionResult GetAllPoliklinikler()
        {
            var poliklinikler = _poliklinikService.GetAllPoliklinikler();
            return Ok(poliklinikler);
        }

        [HttpGet("{id}")]
        public IActionResult GetPoliklinikById(int id)
        {
            var poliklinik = _poliklinikService.GetPoliklinikById(id);
            if (poliklinik == null)
            {
                return NotFound();
            }
            return Ok(poliklinik);
        }

        [HttpPost]
        public IActionResult AddPoliklinik([FromBody] Poliklinik poliklinik)
        {
            _poliklinikService.AddPoliklinik(poliklinik);
            return CreatedAtAction(nameof(GetPoliklinikById), new { id = poliklinik.Id }, poliklinik);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePoliklinik(int id, [FromBody] Poliklinik poliklinik)
        {
            var existingPoliklinik = _poliklinikService.GetPoliklinikById(id);
            if (existingPoliklinik == null)
            {
                return NotFound();
            }

            _poliklinikService.UpdatePoliklinik(poliklinik);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePoliklinik(int id)
        {
            var poliklinik = _poliklinikService.GetPoliklinikById(id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            _poliklinikService.DeletePoliklinik(id);
            return NoContent();
        }
    }

}
