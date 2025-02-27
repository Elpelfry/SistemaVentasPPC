using Shared.Models;
using Shared.Repositories;
using System.Net.Http.Json;

namespace SistemaVentasPPC.Client.Service;

public class ProductoClientService(HttpClient _httpClient) : IClientService<Productos>
{
    public async Task<List<Productos>> GetAllObject()
    {
        var response = await _httpClient.GetAsync("api/Productos");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<Productos>>())!;
        }
        return null!;
    }

    public async Task<Productos> GetObject(int id)
    {
        var response = await _httpClient.GetAsync($"api/Productos/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Productos>())!;
        }
        return null!;
    }

    public async Task<Productos> AddObject(Productos type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Productos", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Productos>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(Productos type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Productos/{type.ProductoId}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Productos/{id}");
        return response.IsSuccessStatusCode;
    }
}
