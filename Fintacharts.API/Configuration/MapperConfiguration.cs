using Fintacharts.API.Application.Mappings;
using Fintacharts.API.Mappings;

namespace Fintacharts.API.Configuration;

public static class MapperConfiguration
{
    public static IServiceCollection ConfigureMapping(this IServiceCollection services)
    {
        return services
            .AddAutoMapper(typeof(RequestsMappings).Assembly)
            .AddAutoMapper(typeof(DtosMappings).Assembly);
    }
}