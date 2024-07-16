using FintachartsAPI.Domain.Models.Assets;
using FintachartsAPI.Domain.Schemas.Assets;
using FintachartsAPI.Domain.Schemas.Base.Interfaces;

namespace FintachartsAPI.Domain.Interfaces.Database;

public interface IAssetsRepository : IBaseRepository<AssetModel, Guid>
{
    Task<IEnumerable<AssetModel>> GetDetailedAsync(IEnumerable<Guid> ids);
    Task<IPaginatedResponseSchema<AssetModel>> GetSimplePaginatedAsync(IPaginatedSchema schema);
    Task<ICollection<Guid>> GetAllIdsAsync();
    Task<bool> UpdateFromStreamAsync(UpdateAssetDataSchema updateSchema);
    Task<bool> AnyAsync();
}