using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Repositories;

namespace SistemaVentasPPC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfiguracionesController(IServerService<Configuraciones> _service) : ControllerBase
{
    // GET: api/Configuraciones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Configuraciones>>> GetConfiguraciones()
    {
        return await _service.GetAllObject();
    }

    // GET: api/Configuraciones/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Configuraciones>> GetConfiguraciones(int id)
    {
        var configuraciones = await _service.GetObject(id);

        if (configuraciones == null)
        {
            return NotFound();
        }

        return configuraciones;
    }

    // POST: api/Configuraciones
    [HttpPost]
    public async Task<ActionResult<Configuraciones>> PostConfiguraciones(Configuraciones configuraciones)
    {
        var conf = await _service.AddObject(configuraciones);

        return CreatedAtAction(nameof(GetConfiguraciones), new { id = conf.ConfiguracionId }, conf);
    }

    // PUT: api/Configuraciones/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutConfiguraciones(int id, Configuraciones configuraciones)
    {
        if (id != configuraciones.ConfiguracionId)
        {
            return BadRequest();
        }
        await _service.UpdateObject(configuraciones);
        return NoContent();
    }

    // DELETE: api/Configuraciones/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConfiguraciones(int id)
    {
        var configuraciones = await _service.DeleteObject(id);
        if (!configuraciones)
        {
            return NotFound();
        }

        return NoContent();
    }

}
