namespace Fintacharts.Api.WebSocket.DataProvider.Configuration.Endpoints;

public class StreamingEndpointModel
{
    public const string ConfigSectionName = "StreamingEndpoint";
    public string InstrumentData { get; set; }
}