using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrosWasm.Server.DAL;
using RegistrosWasm.Shared.Models;

namespace RegistrosWasm.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly ClientesContext _context;

    public ClientesController(ClientesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
    {
        if(_context.Clientes == null)
        {
            return NotFound();
        }
        return await _context.Clientes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Clientes>> GetClientes(int id)
    {
        if(_context.Clientes == null)
        {
            return NotFound();
        }

        var clientes = await _context.Clientes.FindAsync(id);

        if (clientes == null)
        {
            return NotFound();
        }

        return clientes;
    }

    [HttpPost]
    public async Task<ActionResult<Clientes>> PostCliente(Clientes Cliente)
    {
        if (!ClientesExiste(Cliente.ClienteId))
            _context.Clientes.Add(Cliente);
        else
            _context.Clientes.Update(Cliente);

        await _context.SaveChangesAsync();
        return Ok(Cliente);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteClientes(int id)
    {
        if(_context.Clientes == null)
        {
            return NotFound();
        }

        var clientes = await _context.Clientes.FindAsync(id);

        if(clientes == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(clientes);
        await _context.AddRangeAsync(clientes);

        return NoContent();
    }

    private bool ClientesExiste(int id)
    {
        return (_context.Clientes?.Any(c => c.ClienteId == id)).GetValueOrDefault();
    }
}

