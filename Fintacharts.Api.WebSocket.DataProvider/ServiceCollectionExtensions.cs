using Fintacharts.Api.WebSocket.DataProvider.Configuration.Endpoints;
using Fintacharts.Api.WebSocket.DataProvider.Configuration.Models;
using Fintacharts.Api.WebSocket.DataProvider.DataProviders;
using Fintacharts.Api.WebSocket.DataProvider.Interfaces.Servers;
using Fintacharts.Api.WebSocket.DataProvider.Mappings;
using Fintacharts.Api.WebSocket.DataProvider.Servers;
using FintachartsAPI.Domain.Interfaces.DataProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fintacharts.Api.WebSocket.DataProvider;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebSocketDataProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        
        services  
            .Configure<WebSocketConfigurationModel>(configuration.GetSection(WebSocketConfigurationModel.ConfigSectionName))
            .Configure<StreamingEndpointModel>(configuration.GetSection(StreamingEndpointModel.ConfigSectionName));
        
        services.AddAutoMapper(typeof(ResponseMappings).Assembly);
        
        return services
            .AddTransient<IWebSocketServer, WebSocketServer>()
            .AddScoped<IStreamingDataProvider, StreamingDataProvider>();
    }
}