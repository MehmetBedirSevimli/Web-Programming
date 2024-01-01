using Microsoft.AspNetCore.Mvc;
using WebProgramlama.Models;
using WebProgramlama.Services;

//[Route("api/[controller]")]
//[ApiController]
public class DoktorController : ControllerBase
{
    private readonly IDoktorService _doktorService;

    public DoktorController(IDoktorService doktorService)
    {
        _doktorService = doktorService;
    }

    [HttpGet]
    public IActionResult GetAllDoktorlar()
    {
        var doktorlar = _doktorService.GetAllDoktorlar();
        return Ok(doktorlar);
    }

    [HttpGet("{id}")]
    public IActionResult GetDoktorById(int id)
    {
        var doktor = _doktorService.GetDoktorById(id);
        if (doktor == null)
        {
            return NotFound();
        }
        return Ok(doktor);
    }

    [HttpPost]
    public IActionResult AddDoktor([FromBody] Doktor doktor)
    {
        _doktorService.AddDoktor(doktor);
        return CreatedAtAction(nameof(GetDoktorById), new { id = doktor.Id }, doktor);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDoktor(int id, [FromBody] Doktor doktor)
    {
        var existingDoktor = _doktorService.GetDoktorById(id);
        if (existingDoktor == null)
        {
            return NotFound();
        }

        _doktorService.UpdateDoktor(doktor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDoktor(int id)
    {
        var doktor = _doktorService.GetDoktorById(id);
        if (doktor == null)
        {
            return NotFound();
        }

        _doktorService.DeleteDoktor(id);
        return NoContent();
    }




}
