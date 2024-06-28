using Microsoft.AspNetCore.Mvc;
using VideoTienda.Models;

namespace VideoTienda.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController: ControllerBase
{
    private static readonly List<Cliente> Clientes = new List<Cliente>
    {
        new Cliente(){Id = 1, Nombre = "Testino Probino", Email = "testino@mail.com"},
        new Cliente(){Id = 2, Nombre = "John Doe", Email = "johndoe@mail.com"},
        new Cliente(){Id = 3, Nombre = "John Snow", Email = "johnsnow@mail.com"},
    };
    
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
    
    // POST: api/cliente
    [HttpPost]
    public ActionResult<Cliente> Post([FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        cliente.Id = Clientes.Count + 1;
        Clientes.Add(cliente);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }
}
