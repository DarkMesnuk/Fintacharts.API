using Fintacharts.API.Application.BackGround;
using Fintacharts.API.Application.Handlers.Assets;
using Fintacharts.API.Application.PipelineBehaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Fintacharts.API.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddHostedService<AssetsWorker>();
        
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAssetsQueryHandler).Assembly))
            .AddValidatorsFromAssembly(typeof(GetAssetsRequestValidator).Assembly)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}