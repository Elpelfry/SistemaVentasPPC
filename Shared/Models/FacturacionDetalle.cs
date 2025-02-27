using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class FacturacionDetalle
{
	[Key]
	public int DetalleID { get; set; }

	[ForeignKey("Facturaciones")]
	public int FacturacionId { get; set; }

	[ForeignKey("Productos")]
	public int ProductoId { get; set; }

	[Required(ErrorMessage = "Es requerida la cantidad")]
	public int Cantidad { get; set; }
}
