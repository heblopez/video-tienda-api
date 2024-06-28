using Microsoft.AspNetCore.Mvc;
using VideoTienda.Models;

namespace VideoTienda.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoController: ControllerBase
{
    private static readonly List<Video> Videos = new List<Video>();
    
    // GET: api/video
    [HttpGet]
    public ActionResult<IEnumerable<Video>> Get()
    {
        return Ok(Videos);
    }
    
    // GET: api/video/{id}
    [HttpGet("{id}")]
    public ActionResult<Video> Get(int id)
    {
        var video = Videos.FirstOrDefault(v => v.Id == id);
        if (video == null)
        {
            return NotFound();
        }
        return Ok(video);
    }
    
    // POST: api/video
    [HttpPost]
    public ActionResult<Video> Post([FromBody] Video video)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        video.Id = Videos.Count + 1;
        Videos.Add(video);
        return CreatedAtAction(nameof(Get), new { id = video.Id }, video);
    }
    
    // PUT: api/video/{id}
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Video video)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existingVideo = Videos.FirstOrDefault(v => v.Id == id);
        if (existingVideo == null)
        {
            return NotFound();
        }
        existingVideo.Titulo = video.Titulo;
        existingVideo.Genero = video.Genero;
        existingVideo.FechaLanzamiento = video.FechaLanzamiento;
        existingVideo.Precio = video.Precio;
        existingVideo.ClienteId = video.ClienteId;
        return NoContent();
    }
    
    // DELETE: api/video/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var video = Videos.FirstOrDefault(v => v.Id == id);
        if (video == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}