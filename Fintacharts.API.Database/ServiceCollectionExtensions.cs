using Fintacharts.API.Database.Configuration;
using Fintacharts.API.Database.Mappers;
using Fintacharts.API.Database.Repositories;
using FintachartsAPI.Domain.Interfaces.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fintacharts.API.Database;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkNpgsql()
            .AddDbContextPool<FintachartsContext>(
                options => options.UseNpgsql(
                configuration.GetPostgreSQLConnectionString(),
                    sqlOptions =>
                        sqlOptions.MigrationsAssembly(typeof(FintachartsContext).GetTypeInfo().Assembly.GetName().Name)),
                configuration.GetDbContextPoolSize());
        
        services.AddAutoMapper(typeof(MappingRepositoryProfile).Assembly);

        services
            .AddScoped<IAssetsRepository, AssetsRepository>();

        return services;
    }

}
