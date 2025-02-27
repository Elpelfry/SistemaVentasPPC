using Shared.Models;
using Shared.Repositories;
using System.Net.Http.Json;

namespace SistemaVentasPPC.Client.Service;

public class FacturacionesClientService(HttpClient _httpClient) : IClientService<Facturaciones>
{
    public async Task<List<Facturaciones>> GetAllObject()
    {
        var response = await _httpClient.GetAsync("api/Facturaciones");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<Facturaciones>>())!;
        }
        return null!;
    }

    public async Task<Facturaciones> GetObject(int id)
    {
        var response = await _httpClient.GetAsync($"api/Facturaciones/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Facturaciones>())!;
        }
        return null!;
    }

    public async Task<Facturaciones> AddObject(Facturaciones type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Facturaciones", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Facturaciones>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(Facturaciones type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Facturaciones/{type.FacturacionId}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Facturaciones/{id}");
        return response.IsSuccessStatusCode;
    }
}
