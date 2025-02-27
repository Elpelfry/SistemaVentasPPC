
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class ProductoDto
{
    public int ProductoId { get; set; }
    public string? Codigo { get; set; }
    public double Precio { get; set; }
    public double Costo { get; set; }
    public string? Nombre { get; set; }
    public int Cantidad { get; set; }
    public int Descuento { get; set; }
    public int ITBIS { get; set; }
    public int Ganancia { get; set; }
    public bool EsDisponible { get; set; }
}
