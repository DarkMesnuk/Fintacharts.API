using FintachartsAPI.Domain.Interfaces.Database;
using FintachartsAPI.Domain.Interfaces.DataProvider;
using FintachartsAPI.Domain.Interfaces.Seeders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FintachartsAPI.Domain.Seeders;

public class AssetsSeeder(
    ILogger<AssetsSeeder> logger,
    IServiceProvider serviceProvider
    ) : IAssetsSeeder
{
    public async Task InitAllAvailableAssets()
    {
        using var scope = serviceProvider.CreateScope();
        var assetsRepository = scope.ServiceProvider.GetRequiredService<IAssetsRepository>();

        var isEmpty = await assetsRepository.AnyAsync();

        if (!isEmpty)
        {
            var assetsDataProvider = scope.ServiceProvider.GetRequiredService<IAssetsDataProvider>();

            var assets = await assetsDataProvider.GetAllAssetsAsync();

            var isSuccess = await assetsRepository.CreateAsync(assets);

            if (!isSuccess)
                logger.LogCritical("[AssetsSeeder] Failed to Create assets");
        }
    }
}