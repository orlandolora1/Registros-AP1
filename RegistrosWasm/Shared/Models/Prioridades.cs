using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrosWasm.Shared.Models;

public class Prioridades
{
    [Key]

    public int PrioridadId { get; set; }

    [Required(ErrorMessage = "La descripcion es obligatoria")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Los dias de compromiso son obligatoria")]
    public int DiasCompromiso { get; set; }
}
