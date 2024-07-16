using FintachartsAPI.Domain.Interfaces.Seeders;
using FintachartsAPI.Domain.Seeders;
using Microsoft.Extensions.DependencyInjection;

namespace FintachartsAPI.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddScoped<IAssetsSeeder, AssetsSeeder>();
    }
}