using Microsoft.AspNetCore.Mvc;
using WebProgramlama.Models;
using WebProgramlama.Services;

namespace WebProgramlama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnaBilimDaliController : ControllerBase
    {
        private readonly AnaBilimDaliService _anaBilimDaliService;

        public AnaBilimDaliController(AnaBilimDaliService anaBilimDaliService)
        {
            _anaBilimDaliService = anaBilimDaliService;
        }

        [HttpGet]
        public IActionResult GetAllAnaBilimDallari()
        {
            var anaBilimDallari = _anaBilimDaliService.GetAllAnaBilimDallari();
            return Ok(anaBilimDallari);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnaBilimDaliById(int id)
        {
            var anaBilimDali = _anaBilimDaliService.GetAnaBilimDaliById(id);
            if (anaBilimDali == null)
            {
                return NotFound();
            }
            return Ok(anaBilimDali);
        }

        [HttpPost]
        public IActionResult AddAnaBilimDali([FromBody] AnaBilimDali anaBilimDali)
        {
            _anaBilimDaliService.AddAnaBilimDali(anaBilimDali);
            return CreatedAtAction(nameof(GetAnaBilimDaliById), new { id = anaBilimDali.Id }, anaBilimDali);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnaBilimDali(int id, [FromBody] AnaBilimDali anaBilimDali)
        {
            var existingAnaBilimDali = _anaBilimDaliService.GetAnaBilimDaliById(id);
            if (existingAnaBilimDali == null)
            {
                return NotFound();
            }

            _anaBilimDaliService.UpdateAnaBilimDali(anaBilimDali);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnaBilimDali(int id)
        {
            var anaBilimDali = _anaBilimDaliService.GetAnaBilimDaliById(id);
            if (anaBilimDali == null)
            {
                return NotFound();
            }

            _anaBilimDaliService.DeleteAnaBilimDali(id);
            return NoContent();
        }
    }

}
