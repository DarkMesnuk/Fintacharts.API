namespace Fintacharts.Api.HTTP.DataProvider.Models;

public class ApiRequestModel
{
    public required string Url { get; init; }
    public string? AccessToken { get; init; }
    public required HttpMethod Type { get; init; }
    public object? Data { get; init; }
    public string ContentType { get; set; } = "application/json";
}