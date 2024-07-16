using FintachartsAPI.Domain.Interfaces.Database;
using FintachartsAPI.Domain.Interfaces.DataProvider;
using FintachartsAPI.Domain.Schemas.Assets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fintacharts.API.Application.BackGround;

public class AssetsWorker(
    IServiceProvider serviceProvider
    ) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _ = Task.Run(DoWorkAsync, stoppingToken);
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    private async Task DoWorkAsync()
    {
        using var scope = serviceProvider.CreateScope();
        var streamingDataProvider = scope.ServiceProvider.GetRequiredService<IStreamingDataProvider>();
        var assetsRepository = scope.ServiceProvider.GetRequiredService<IAssetsRepository>();

        ICollection<Guid> assetIds;
        
        do
        {
            assetIds = await assetsRepository.GetAllIdsAsync();    
        } while (assetIds.Count == 0);
        
        var requestId = 0;

        await streamingDataProvider.StartConnectionAsync(UpdateAssetData(assetsRepository));
        
        foreach (var assetId in assetIds)
            await streamingDataProvider.SubscribeToGetAssetsDataAsync(assetId, ++requestId);
        
        await Task.Delay(Timeout.Infinite);
    }

    private Action<UpdateAssetDataSchema> UpdateAssetData(IAssetsRepository assetsRepository)
    {
        return updateSchema => {
            if(updateSchema.Id != default)
                assetsRepository.UpdateFromStreamAsync(updateSchema).GetAwaiter();
        };
    }

    public override Task StopAsync(CancellationToken stoppingToken)
    {
        return base.StopAsync(stoppingToken);
    }
}