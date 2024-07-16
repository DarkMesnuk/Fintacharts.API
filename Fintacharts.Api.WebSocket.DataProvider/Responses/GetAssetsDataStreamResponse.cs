using FintachartsAPI.Domain.Models.Assets;
using Newtonsoft.Json;

namespace Fintacharts.Api.WebSocket.DataProvider.Responses;

public class GetAssetsDataStreamResponse
{
    [JsonProperty(PropertyName = "InstrumentId")]
    public string Id { get; init; }
    public AssetPriceChangeModel? Ask { get; init; }
    public AssetPriceChangeModel? Bid { get; init; }
    public AssetPriceChangeModel? Last { get; init; }
}