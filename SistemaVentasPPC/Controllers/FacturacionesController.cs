using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Repositories;

namespace SistemaVentasPPC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacturacionesController(IServerService<Facturaciones> _service) : ControllerBase
{
    // GET: api/Facturaciones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Facturaciones>>> GetFacturaciones()
    {
        return await _service.GetAllObject();
    }

    // GET: api/Facturaciones/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Facturaciones>> GetFacturaciones(int id)
    {
        var facturaciones = await _service.GetObject(id);

        if (facturaciones == null)
        {
            return NotFound();
        }

        return facturaciones;
    }

    // POST: api/Facturaciones
    [HttpPost]
    public async Task<ActionResult<Facturaciones>> PostFacturaciones(Facturaciones facturaciones)
    {
        var fac = await _service.AddObject(facturaciones);

        return CreatedAtAction(nameof(GetFacturaciones), new { id = fac.FacturacionId }, fac);
    }

    // PUT: api/Facturaciones/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFacturaciones(int id, Facturaciones facturaciones)
    {
        if (id != facturaciones.FacturacionId)
        {
            return BadRequest();
        }
        await _service.UpdateObject(facturaciones);
        return NoContent();
    }

    // DELETE: api/Facturaciones/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFacturaciones(int id)
    {
        var facturaciones = await _service.DeleteObject(id);
        if (!facturaciones)
        {
            return NotFound();
        }

        return NoContent();
    }
}
