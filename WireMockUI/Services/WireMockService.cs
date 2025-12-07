using WireMock.Admin.Mappings;
using WireMock.Admin.Requests;
using WireMock.Client;

namespace WireMockUI.Services;

public class WireMockService : IWireMockService
{
    private readonly IWireMockAdminApi _adminApi;

    public WireMockService(IWireMockAdminApi adminApi)
    {
        _adminApi = adminApi;
    }

    public async Task<IList<MappingModel>?> GetMappingsAsync()
    {
        try
        {
            return await _adminApi.GetMappingsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching mappings: {ex.Message}");
            return null;
        }
    }

    public async Task<MappingModel?> GetMappingAsync(Guid id)
    {
        try
        {
            return await _adminApi.GetMappingAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching mapping: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> CreateMappingAsync(MappingModel mapping)
    {
        try
        {
            Console.WriteLine($"Creating mapping: Title={mapping.Title}, Path={mapping.Request?.Url ?? mapping.Request?.Path?.ToString() ?? "N/A"}");
            var result = await _adminApi.PostMappingAsync(mapping);
            Console.WriteLine($"Create mapping result: Status={result?.Status}, Guid={result?.Guid}");
            return result?.Status == "Mapping added" || result?.Status?.Contains("created") == true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating mapping: {ex.GetType().Name}: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            return false;
        }
    }

    public async Task<bool> UpdateMappingAsync(Guid id, MappingModel mapping)
    {
        try
        {
            var result = await _adminApi.PutMappingAsync(id, mapping);
            return result?.Status == "Mapping updated" || result?.Status?.Contains("updated") == true;
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
            var result = await _adminApi.DeleteMappingAsync(id);
            return result?.Status == "Mapping removed" || result?.Status?.Contains("deleted") == true || result?.Status?.Contains("removed") == true;
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
            var result = await _adminApi.ResetMappingsAsync();
            return result?.Status == "Mappings reset" || result?.Status?.Contains("reset") == true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error resetting mappings: {ex.Message}");
            return false;
        }
    }

    public async Task<IList<LogEntryModel>?> GetRequestsAsync()
    {
        try
        {
            return await _adminApi.GetRequestsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching requests: {ex.Message}");
            return null;
        }
    }

    public async Task<LogEntryModel?> GetRequestAsync(Guid id)
    {
        try
        {
            return await _adminApi.GetRequestAsync(id);
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
            var result = await _adminApi.ResetRequestsAsync();
            return result?.Status == "Requests reset" || result?.Status?.Contains("reset") == true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error resetting requests: {ex.Message}");
            return false;
        }
    }
}
