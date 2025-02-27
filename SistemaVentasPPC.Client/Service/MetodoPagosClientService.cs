using Shared.Models;
using Shared.Repositories;
using System.Net.Http.Json;

namespace SistemaVentasPPC.Client.Service;

public class MetodoPagosClientService(HttpClient _httpClient) : IClientService<MetodoPagos>
{
    public async Task<List<MetodoPagos>> GetAllObject()
    {
        var response = await _httpClient.GetAsync("api/MetodoPagos");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<MetodoPagos>>())!;
        }
        return null!;
    }

    public async Task<MetodoPagos> GetObject(int id)
    {
        var response = await _httpClient.GetAsync($"api/MetodoPagos/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<MetodoPagos>())!;
        }
        return null!;
    }

    public async Task<MetodoPagos> AddObject(MetodoPagos type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/MetodoPagos", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<MetodoPagos>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(MetodoPagos type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/MetodoPagos/{type.MetodoPagoId}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/MetodoPagos/{id}");
        return response.IsSuccessStatusCode;
    }
}
