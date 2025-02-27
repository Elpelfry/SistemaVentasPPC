using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Repositories;
using SistemaVentasPPC.DAL;

namespace SistemaVentasPPC.Service;

public class ProductosService(Contexto _contexto) : IServerService<Productos>
{
    public async Task<List<Productos>> GetAllObject()
    {
        return await _contexto.Productos.ToListAsync();
    }

    public async Task<Productos> GetObject(int id)
    {
        return (await _contexto.Productos.FirstOrDefaultAsync(p => p.ProductoId == id))!;
    }

    public async Task<Productos> AddObject(Productos type)
    {
        _contexto.Productos.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Productos type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var producto = await _contexto.Productos.FindAsync(id);
        if (producto == null)
            return false;

        _contexto.Productos.Remove(producto);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
