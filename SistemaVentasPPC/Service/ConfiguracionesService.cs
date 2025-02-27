using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Repositories;
using SistemaVentasPPC.DAL;

namespace SistemaVentasPPC.Service;

public class ConfiguracionesService(Contexto _contexto) : IServerService<Configuraciones>
{
    public async Task<List<Configuraciones>> GetAllObject()
    {
        return await _contexto.Configuraciones.ToListAsync();
    }

    public async Task<Configuraciones> GetObject(int id)
    {
        return (await _contexto.Configuraciones.FirstOrDefaultAsync(c => c.ConfiguracionId == id))!;
    }

    public async Task<Configuraciones> AddObject(Configuraciones type)
    {
        _contexto.Configuraciones.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Configuraciones type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var configuracion = await _contexto.Configuraciones.FindAsync(id);
        if (configuracion == null)
            return false;

        _contexto.Configuraciones.Remove(configuracion);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
