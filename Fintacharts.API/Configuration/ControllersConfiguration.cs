using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fintacharts.API.Configuration;

public static class ControllersConfiguration
{
    public static IMvcBuilder ConfigureControllers(this IServiceCollection services)
    {
        return services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
    }
}