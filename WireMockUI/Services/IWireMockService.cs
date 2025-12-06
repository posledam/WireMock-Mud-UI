using WireMock.Admin.Mappings;
using WireMock.Admin.Requests;

namespace WireMockUI.Services;

public interface IWireMockService
{
    Task<IList<MappingModel>?> GetMappingsAsync();
    Task<MappingModel?> GetMappingAsync(Guid id);
    Task<bool> CreateMappingAsync(MappingModel mapping);
    Task<bool> UpdateMappingAsync(Guid id, MappingModel mapping);
    Task<bool> DeleteMappingAsync(Guid id);
    Task<bool> ResetMappingsAsync();
    Task<IList<LogEntryModel>?> GetRequestsAsync();
    Task<LogEntryModel?> GetRequestAsync(Guid id);
    Task<bool> ResetRequestsAsync();
}
