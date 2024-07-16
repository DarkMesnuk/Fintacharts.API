using Fintacharts.API.Database.Configuration.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Fintacharts.API.Database.Configuration;

public static class DatabaseConfiguration
{
    internal static string GetPostgreSQLConnectionString(this IConfiguration configuration)
    {
        var config = configuration.GetDbConnectionConfiguration();
        
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = config.Host,
            Port = config.Port,
            Database = config.Name,
            Username = config.User,
            Password = config.Password,
            CommandTimeout = config.CommandTimeout
        };

        if (config.Pooling)
        {
            builder.Pooling = config.Pooling;
            builder.MinPoolSize = config.MinPoolSize;
            builder.MaxPoolSize = config.MaxPoolSize;
            builder.ConnectionIdleLifetime = config.ConnectionIdleLifetime;
            builder.ConnectionPruningInterval = config.ConnectionPruningInterval;
        }

        return builder.ToString();
    }
    
    internal static PostgreSqlConnectionConfiguration? GetDbConnectionConfiguration(this IConfiguration configuration) =>
        configuration.GetSection("Database").Get<PostgreSqlConnectionConfiguration>();

    internal static int GetDbContextPoolSize(this IConfiguration configuration) => 
        configuration.GetValue("Database:MaxPoolSize", 2048);
}