using Newtonsoft.Json;

namespace Fintacharts.Api.WebSocket.DataProvider.Payloads;

public class SubscribeToGetAssetDataPayload
{
    public required string Type { get; init; }
    public required string Id { get; init; }
    [JsonProperty(PropertyName = "InstrumentId")]
    public required string AssetId { get; init; }
    public required string Provider  { get; init; }
    public required bool Subscribe { get; init; }
    public required string[] Kinds { get; init; }
}