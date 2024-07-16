using Fintacharts.API.Application;
using Fintacharts.API.Database;
using Fintacharts.Api.HTTP.DataProvider;
using Fintacharts.API.Middlewares;
using Fintacharts.Api.WebSocket.DataProvider;
using FintachartsAPI.Domain;

namespace Fintacharts.API.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        
        services.ConfigureControllers();

        services.AddEndpointsApiExplorer();

        services.ConfigureSwagger();

        services.AddOptions();

        services.ConfigureMapping();

        services.AddDomain();
        services.AddApplication();
        services.AddDatabase(builder.Configuration);

        services.AddHttpDataProvider(builder.Configuration);
        services.AddWebSocketDataProvider(builder.Configuration);
        
        return services;
    }
}