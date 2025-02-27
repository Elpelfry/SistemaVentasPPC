using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Repositories;
using SistemaVentasPPC.DAL;

namespace SistemaVentasPPC.Service;

public class MetodoPagosService(Contexto _contexto) : IServerService<MetodoPagos>
{
    public async Task<List<MetodoPagos>> GetAllObject()
    {
        return await _contexto.MetodoPagos.ToListAsync();
    }

    public async Task<MetodoPagos> GetObject(int id)
    {
        return (await _contexto.MetodoPagos.FirstOrDefaultAsync(m => m.MetodoPagoId == id))!;
    }

    public async Task<MetodoPagos> AddObject(MetodoPagos type)
    {
        _contexto.MetodoPagos.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(MetodoPagos type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var metodoPago = await _contexto.MetodoPagos.FindAsync(id);
        if (metodoPago == null)
            return false;

        _contexto.MetodoPagos.Remove(metodoPago);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
