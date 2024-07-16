using FintachartsAPI.Domain.Schemas.Assets;

namespace FintachartsAPI.Domain.Interfaces.DataProvider;

public interface IStreamingDataProvider : IDisposable
{
    Task<bool> StartConnectionAsync(Action<UpdateAssetDataSchema> eventHandler);
    Task SubscribeToGetAssetsDataAsync(Guid assetId, int requestId);
}