using WireMockUI.Models;

namespace WireMockUI.Services;

public interface IWireMockService
{
    Task<MappingsList?> GetMappingsAsync();
    Task<WireMockMapping?> GetMappingAsync(Guid id);
    Task<bool> CreateMappingAsync(CreateMappingRequest request);
    Task<bool> UpdateMappingAsync(Guid id, CreateMappingRequest request);
    Task<bool> DeleteMappingAsync(Guid id);
    Task<bool> ResetMappingsAsync();
    Task<RequestsList?> GetRequestsAsync();
    Task<WireMockRequest?> GetRequestAsync(Guid id);
    Task<bool> ResetRequestsAsync();
}
