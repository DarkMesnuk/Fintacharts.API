namespace Fintacharts.Api.WebSocket.DataProvider.Models;

public class ConnectRequestModel
{
    public required string Url { get; init; }
    public string? AccessToken { get; init; }
}