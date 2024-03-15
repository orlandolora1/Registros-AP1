using Microsoft.EntityFrameworkCore;
using RegistrosWasm.Shared.Models;

namespace RegistrosWasm.Server.DAL;

public class TicketContext : DbContext
{
	public TicketContext(DbContextOptions<TicketContext> options)
		: base(options) { }

	public DbSet<Tickets> Tickets { get; set; }
}



