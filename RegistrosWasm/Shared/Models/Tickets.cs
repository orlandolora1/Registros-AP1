using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrosWasm.Shared.Models;

public class Tickets
{
	[Key]

	[Required(ErrorMessage = "El ticketId es un campo obligatorio")]
	public int TicketId { get; set; }

	public DateTime Fecha { get; set; }

	public int ClienteId { get; set; }

	public int SistemaId { get; set; }

	public int PrioridadId { get; set; }

	public string? SolicitadoPor { get; set; }

	public string Asunto { get; set; } = "";

	public string? Descripcion { get; set; }

	[Required(ErrorMessage = "El campo (Id) es obligatorio")]
	public int Id { get; set; }

	[Required(ErrorMessage = "El campo (TicketId) es obligatorio")]
	public int TicktetId { get; set; }

	[Required(ErrorMessage = "El campo (Emisor) es obligatorio")]
	public string Emisor { get; set; } = "";

	[Required(ErrorMessage = "Debe dejar un detalle de mensaje")]
	public string Mensaje { get; set; } = "";
}
