using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrosWasm.Shared.Models;

public class Clientes
{
	[Key]

	public int ClienteId { get; set; }

	[Required(ErrorMessage = "El nombre es un campo obligatorio")]
	public string Nombres { get; set; } = "";

	[StringLength(12)]
	public string? Telefono { get; set; }

	[StringLength(12)]
	public string? Celular { get; set; }

	[StringLength(13)]
	[Required(ErrorMessage = "El Rnc es un campo obligatorio")]
	public string? Rnc { get; set; }

	public string? Email { get; set; }

	public string? Direccion { get; set; }

	public int VecesAsignado { get; set; }

	public int Id { get; set; }

	public int SistemaId { get; set; }

	public int TerminalesPermitidas { get; set; }

	[Required(ErrorMessage = "El campo (Emisor) es obligatorio")]
	public string Emisor { get; set; } = "";

	[Required(ErrorMessage = "Debe dejar un detalle de mensaje")]
	public string Mensaje { get; set; } = "";
}

