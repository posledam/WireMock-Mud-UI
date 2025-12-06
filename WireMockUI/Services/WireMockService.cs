using System.Net.Http.Json;
using System.Text.Json;
using WireMockUI.Models;

namespace WireMockUI.Services;

public class WireMockService : IWireMockService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public WireMockService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<MappingsList?> GetMappingsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<MappingsList>("__admin/mappings", _jsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching mappings: {ex.Message}");
            return null;
        }
    }

    public async Task<WireMockMapping?> GetMappingAsync(Guid id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<WireMockMapping>($"__admin/mappings/{id}", _jsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching mapping: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> CreateMappingAsync(CreateMappingRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("__admin/mappings", request, _jsonOptions);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating mapping: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> UpdateMappingAsync(Guid id, CreateMappingRequest request)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"__admin/mappings/{id}", request, _jsonOptions);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating mapping: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteMappingAsync(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"__admin/mappings/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting mapping: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> ResetMappingsAsync()
    {
        try
        {
            var response = await _httpClient.DeleteAsync("__admin/mappings");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error resetting mappings: {ex.Message}");
            return false;
        }
    }

    public async Task<RequestsList?> GetRequestsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<RequestsList>("__admin/requests", _jsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching requests: {ex.Message}");
            return null;
        }
    }

    public async Task<WireMockRequest?> GetRequestAsync(Guid id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<WireMockRequest>($"__admin/requests/{id}", _jsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching request: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> ResetRequestsAsync()
    {
        try
        {
            var response = await _httpClient.DeleteAsync("__admin/requests");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error resetting requests: {ex.Message}");
            return false;
        }
    }
}
