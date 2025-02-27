
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Facturaciones
{
	[Key]
	public int FacturacionId { get; set; }
	[ForeignKey("Configuraciones")]
	public int ConfiguracionId { get; set; }

	[Required(ErrorMessage = "El Combre del cliente es obligatorio")]
	[RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
	public string? NombreCliente { get; set; }

	[ForeignKey("MetodoPagos")]
	public int MetodoPagoId { get; set; }

	[Required(ErrorMessage = "Es requerido")]
	public DateTime Fecha { get; set; } = DateTime.Now;

	public double SubTotal { get; set; }

	public double Total { get; set; }

	public double ITBS { get; set; }

	public double Recibido { get; set; }

	public double Devuelta { get; set; }

	[ForeignKey("Condiciones")]
	public int CondicionId { get; set; }

	public bool Eliminada { get; set; }

	[ForeignKey("FacturacionId")]
	public ICollection<FacturacionDetalle> FacturacionDetalle { get; set; } = new List<FacturacionDetalle>();
}
