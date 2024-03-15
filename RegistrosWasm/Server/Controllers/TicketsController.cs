using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrosWasm.Server.DAL;
using RegistrosWasm.Shared.Models;

namespace RegistrosWasm.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
	private readonly TicketContext _context;

	public TicketsController(TicketContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Tickets>>> GetClientes()
	{
		if (_context.Tickets == null)
		{
			return NotFound();
		}
		return await _context.Tickets.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Tickets>> GetClientes(int id)
	{
		if (_context.Tickets == null)
		{
			return NotFound();
		}

		var tickets = await _context.Tickets.FindAsync(id);

		if (tickets == null)
		{
			return NotFound();
		}

		return tickets;
	}

	[HttpPost]
	public async Task<ActionResult<Tickets>> PostCliente(Tickets ticket)
	{
		if (!ClientesExiste(ticket.ClienteId))
			_context.Tickets.Add(ticket);
		else
			_context.Tickets.Update(ticket);

		await _context.SaveChangesAsync();
		return Ok(ticket);
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteClientes(int id)
	{
		if (_context.Tickets == null)
		{
			return NotFound();
		}

		var tickets = await _context.Tickets.FindAsync(id);

		if (tickets == null)
		{
			return NotFound();
		}

		_context.Tickets.Remove(tickets);
		await _context.AddRangeAsync(tickets);

		return NoContent();
	}

	private bool ClientesExiste(int id)
	{
		return (_context.Tickets?.Any(c => c.ClienteId == id)).GetValueOrDefault();
	}
}

