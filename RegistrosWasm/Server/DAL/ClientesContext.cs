using Microsoft.EntityFrameworkCore;
using RegistrosWasm.Shared.Models;

namespace RegistrosWasm.Server.DAL;

public class ClientesContext : DbContext
{
    public ClientesContext(DbContextOptions<ClientesContext> options)
        :base(options) { }

    public DbSet<Clientes> Clientes { get; set; }
}

