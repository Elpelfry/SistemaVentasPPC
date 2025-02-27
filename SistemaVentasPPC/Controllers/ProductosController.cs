using System;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Repositories;

namespace SistemaVentasPPC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductosController(IServerService<Productos> _service) : ControllerBase
{
    // GET: api/Productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
    {
        return await _service.GetAllObject();
    }

    // GET: api/Productos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Productos>> GetProductos(int id)
    {
        var productos = await _service.GetObject(id);

        if (productos == null)
        {
            return NotFound();
        }

        return productos;
    }

    // POST: api/Productos
    [HttpPost]
    public async Task<ActionResult<Productos>> PostProductos(Productos productos)
    {
        var prod = await _service.AddObject(productos);

        return CreatedAtAction(nameof(GetProductos), new { id = prod.ProductoId }, prod);
    }

    // PUT: api/Productos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductos(int id, ProductoDto productos)
    {
        if(productos.Cantidad == 0)
            productos.EsDisponible = false;

        var newprd = new Productos
        {
            ProductoId = id,
            Codigo = productos.Codigo,
            Precio = productos.Precio,
            Costo = productos.Costo,
            Nombre = productos.Nombre,
            Cantidad = productos.Cantidad,
            Descuento = productos.Descuento,
            ITBIS = productos.ITBIS,
            Ganancia = productos.Ganancia,
            EsDisponible = productos.EsDisponible
        };
        if (id != newprd.ProductoId)
        {
            return BadRequest();
        }
        await _service.UpdateObject(newprd);
        return NoContent();
    }

    // DELETE: api/Productos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductos(int id)
    {
        var productos = await _service.DeleteObject(id);
        if (!productos)
        {
            return NotFound();
        }

        return NoContent();
    }
}
