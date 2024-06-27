using Microsoft.AspNetCore.Mvc;
using VideoTienda.Models;

namespace VideoTienda.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController: ControllerBase
{
    private static readonly List<Cliente> Clientes = new List<Cliente>();
    
    // GET: api/cliente
    [HttpGet]
    public ActionResult<IEnumerable<Cliente>> Get()
    {
        return Ok(Clientes);
    }
    
    // GET: api/cliente/{id}
    [HttpGet("{id}")]
    public ActionResult<Cliente> Get(int id)
    {
        var cliente = Clientes.FirstOrDefault(cl => cl.Id == id);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }
}