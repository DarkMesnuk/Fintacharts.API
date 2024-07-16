using Fintacharts.Api.HTTP.DataProvider.Configuration.Endpoints;
using Fintacharts.Api.HTTP.DataProvider.Configuration.Models;
using Fintacharts.Api.HTTP.DataProvider.DataProviders;
using Fintacharts.Api.HTTP.DataProvider.Interfaces;
using Fintacharts.Api.HTTP.DataProvider.Requestors;
using FintachartsAPI.Domain.Interfaces.DataProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fintacharts.Api.HTTP.DataProvider;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHttpDataProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .Configure<ApiConfigurationModel>(configuration.GetSection(ApiConfigurationModel.ConfigSectionName))            
            .Configure<AssetsEndpointModel>(configuration.GetSection(AssetsEndpointModel.ConfigSectionName));
        
        return services
            .AddScoped<IApiRequestor, ApiRequestor>()
            .AddScoped<IAssetsDataProvider, AssetsDataProvider>();
    }
}