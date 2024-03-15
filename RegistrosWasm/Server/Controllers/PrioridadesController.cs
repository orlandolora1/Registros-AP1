using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrosWasm.Server.DAL;
using RegistrosWasm.Shared.Models;
using System.Security.Cryptography.X509Certificates;

namespace RegistrosWasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {
        private readonly PrioridadContext _context;

        public PrioridadesController(PrioridadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prioridades>>> GetPrioridades()
        {
            if (_context.Prioridades == null)
            {
                return NotFound();
            }
            return await _context.Prioridades.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prioridades>> GetPrioridad(int id)
        {
            if (_context.Prioridades == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades.FindAsync(id);
            if (prioridades == null)
            {
                return NotFound();
            }
            return prioridades;
        }

        [HttpPost]
        public async Task<ActionResult<Prioridades>> PostPrioridad(Prioridades Prioridad)
        {
            if (!PrioridadesExiste(Prioridad.PrioridadId))
                _context.Prioridades.Add(Prioridad);
            else
                _context.Prioridades.Update(Prioridad);

            await _context.SaveChangesAsync();
            return Ok(Prioridad);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePrioridades(int id)
        {
            if (_context.Prioridades == null)
            {
                return NotFound();
            }
            var prioridades = await _context.Prioridades.FindAsync(id);
            if (prioridades == null)
            {
                return NotFound();
            }

            _context.Prioridades.Remove(prioridades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrioridadesExiste(int id)
        {
            return (_context.Prioridades?.Any(p => p.PrioridadId == id)).GetValueOrDefault();
        }
    }
}
