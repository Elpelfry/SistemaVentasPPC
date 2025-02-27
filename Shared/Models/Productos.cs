using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Productos
{
	[Key]
	public int ProductoId { get; set; }

	[Required(ErrorMessage = "Es Requerido")]
	public string? Codigo { get; set; }

	[Required(ErrorMessage = "Indique el Precio")]
	[Range(0.01, 1000000000, ErrorMessage = "El Precio debe estar 0.01 y 1000000000")]
	public double Precio { get; set; }

	[Required(ErrorMessage = "Indique el Costo")]
	[Range(0.01, 1000000000, ErrorMessage = "El Costo debe estar 0.01 y 1000000000")]
	public double Costo { get; set; }

	[Required(ErrorMessage = "Es Requerido")]
	public string? Nombre { get; set; }

	[Required(ErrorMessage = "Indique la Cantidad")]
	[Range(1, 1000, ErrorMessage = "La Cantidad debe estar 1 y 1000")]
	public int Cantidad { get; set; }
    [Range(0, 99, ErrorMessage = "El Descuento debe estar 0 y 99")]
    public int Descuento { get; set; }
	public int ITBIS { get; set; }

	[Required(ErrorMessage = "Es Requerido")]
	[Range(20, 30, ErrorMessage = "La Cantidad debe estar 20% y 30%")]
	public int Ganancia { get; set; }
	public bool EsDisponible { get; set; }
}
