using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using Polly;

namespace Fintacharts.API.Database;

public static class WebHostExtensions
{
    public static IServiceProvider MigrateDbContext<TContext>(this IServiceProvider services)
        where TContext : DbContext
    {
        var logger = services.GetRequiredService<ILogger<TContext>>();
        var context = services.GetService<TContext>();

        try
        {
            logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

            var retry = Policy.Handle<NpgsqlException>()
                .WaitAndRetry(new[]
                {
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(8),
                    TimeSpan.FromSeconds(13),
                    TimeSpan.FromSeconds(21)
                });

            retry.Execute(() => context?.Database.Migrate());

            logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
        }

        return services;
    }
}
