using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Fintacharts.API.Middlewares;

public static class SwaggerMiddleware
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        return services
            .AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fintacharts.API",
                    Version = "v1",
                    Description = ""
                });
            });
    }

    public static IApplicationBuilder UseFintachartsSwagger(this IApplicationBuilder app)
    {
        return app
            .UseSwagger(o => {
                o.RouteTemplate = "swagger/{documentName}/docs.json";
            })
            .UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/docs.json", "Fintacharts.API V1");
                c.DocExpansion(DocExpansion.None);
            });
    }
}