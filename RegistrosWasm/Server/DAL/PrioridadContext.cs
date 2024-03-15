using Microsoft.EntityFrameworkCore;
using RegistrosWasm.Shared.Models;

namespace RegistrosWasm.Server.DAL
{
    public class PrioridadContext : DbContext
    {
        public PrioridadContext(DbContextOptions<PrioridadContext> options)
            :base(options) { }

        public DbSet<Prioridades> Prioridades { get; set; }
    }
}
