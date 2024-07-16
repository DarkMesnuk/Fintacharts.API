namespace Fintacharts.Api.WebSocket.DataProvider.Configuration.Models;

public class WebSocketConfigurationModel
{
    public const string ConfigSectionName = "WebSocket";
    public string Url { get; set; }
    public string AccessToken { get; set; }
}