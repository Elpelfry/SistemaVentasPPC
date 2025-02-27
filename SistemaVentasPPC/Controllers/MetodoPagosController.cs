using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Repositories;

namespace SistemaVentasPPC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MetodoPagosController(IServerService<MetodoPagos> _service) : ControllerBase
{
    // GET: api/MetodoPagos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MetodoPagos>>> GetMetodoPagos()
    {
        return await _service.GetAllObject();
    }

    // GET: api/MetodoPagos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MetodoPagos>> GetMetodoPagos(int id)
    {
        var metodoPagos = await _service.GetObject(id);

        if (metodoPagos == null)
        {
            return NotFound();
        }

        return metodoPagos;
    }

    // POST: api/MetodoPagos
    [HttpPost]
    public async Task<ActionResult<MetodoPagos>> PostMetodoPagos(MetodoPagos metodoPagos)
    {
        var met = await _service.AddObject(metodoPagos);

        return CreatedAtAction(nameof(GetMetodoPagos), new { id = met.MetodoPagoId }, met);
    }

    // PUT: api/MetodoPagos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMetodoPagos(int id, MetodoPagos metodoPagos)
    {
        if (id != metodoPagos.MetodoPagoId)
        {
            return BadRequest();
        }
        await _service.UpdateObject(metodoPagos);
        return NoContent();
    }

    // DELETE: api/MetodoPagos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMetodoPagos(int id)
    {
        var metodoPagos = await _service.DeleteObject(id);
        if (!metodoPagos)
        {
            return NotFound();
        }

        return NoContent();
    }
}
