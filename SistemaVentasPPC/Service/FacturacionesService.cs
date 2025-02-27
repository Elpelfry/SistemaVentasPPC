using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Repositories;
using SistemaVentasPPC.DAL;

namespace SistemaVentasPPC.Service;

public class FacturacionesService(Contexto _contexto) : IServerService<Facturaciones>
{
    public async Task<List<Facturaciones>> GetAllObject()
    {
        return await _contexto.Facturaciones.Include(f => f.FacturacionDetalle).ToListAsync();
    }

    public async Task<Facturaciones> GetObject(int id)
    {
        return (await _contexto.Facturaciones.Include(f => f.FacturacionDetalle)
                                             .FirstOrDefaultAsync(f => f.FacturacionId == id))!;
    }

    public async Task<Facturaciones> AddObject(Facturaciones type)
    {
        _contexto.Facturaciones.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Facturaciones type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var facturacion = await _contexto.Facturaciones.FindAsync(id);
        if (facturacion == null)
            return false;

        await _contexto.FacturacionDetalle.Where(f => f.FacturacionId == id).ExecuteDeleteAsync();
        _contexto.Facturaciones.Remove(facturacion);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
