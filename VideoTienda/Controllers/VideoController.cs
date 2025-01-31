using Microsoft.AspNetCore.Mvc;
using VideoTienda.Models;

namespace VideoTienda.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoController: ControllerBase
{
    private static readonly List<Video> Videos = [
        new Video() { Id = 1, Titulo = "Test Video", Genero = "Test Genre", FechaLanzamiento = new DateTime(2024, 1, 1), Precio = 100.0m },
        new Video() { Id = 2, Titulo = "John's video", Genero = "Documentary", FechaLanzamiento = DateTime.Now, Precio = 200.0m },
        new Video() { Id = 3, Titulo = "Video of Ghost the wolf", Genero = "Sci-Fi", FechaLanzamiento = new DateTime(2025, 1, 7), Precio = 500.0m }
    ];
    
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