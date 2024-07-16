using FintachartsAPI.Domain.Models.Assets;

namespace FintachartsAPI.Domain.Interfaces.DataProvider;

public interface IAssetsDataProvider
{
    Task<IEnumerable<AssetModel>> GetAllAssetsAsync();
}