using Fintacharts.Api.HTTP.DataProvider.Configuration.Endpoints;
using Fintacharts.Api.HTTP.DataProvider.Configuration.Models;
using Fintacharts.Api.HTTP.DataProvider.Interfaces;
using Fintacharts.Api.HTTP.DataProvider.Models;
using Fintacharts.Api.HTTP.DataProvider.Responses.Base;
using FintachartsAPI.Domain.Interfaces.DataProvider;
using FintachartsAPI.Domain.Models.Assets;
using Microsoft.Extensions.Options;

namespace Fintacharts.Api.HTTP.DataProvider.DataProviders;

public class AssetsDataProvider(
    IApiRequestor apiRequestor,
    IOptions<ApiConfigurationModel> configurationModel,
    IOptions<AssetsEndpointModel> assetsEndpointModel
    ) : IAssetsDataProvider
{
    public async Task<IEnumerable<AssetModel>> GetAllAssetsAsync()
    {
        var assetsCount = await GetCountSupportedAsync();

        return await GetAssetsAsync(assetsCount);
    }
    
    private async Task<int> GetCountSupportedAsync()
    {
        var request = new ApiRequestModel
        {
            Url = configurationModel.Value.Url + "/" + assetsEndpointModel.Value.GetAssets,
            Type = HttpMethod.Get,
            AccessToken = configurationModel.Value.AccessToken
        };
        
        var response = await apiRequestor.SendAsync<PaginatedResponse<AssetModel>>(request);
        
        return response.Paging.Items;
    }
    
    private async Task<IEnumerable<AssetModel>> GetAssetsAsync(int count)
    {
        var request = new ApiRequestModel
        {
            Url = configurationModel.Value.Url + "/" + assetsEndpointModel.Value.GetAssets,
            Type = HttpMethod.Get,
            AccessToken = configurationModel.Value.AccessToken,
            Data = new { Size = count}
        };
        
        var response = await apiRequestor.SendAsync<PaginatedResponse<AssetModel>>(request);
        
        return response.Data;
    }
}