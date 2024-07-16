using Fintacharts.API.Configuration;
using Fintacharts.API.Database;
using Fintacharts.API.Middlewares;
using FintachartsAPI.Domain.Interfaces.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

builder.Host.ConfigureLogger();

var app = builder
    .Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    services.MigrateDbContext<FintachartsContext>();
    
    var assetsSeeder = services.GetRequiredService<IAssetsSeeder>();
    assetsSeeder?.InitAllAvailableAssets();
}


if (app.Environment.IsDevelopment())
    app.UseFintachartsSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();