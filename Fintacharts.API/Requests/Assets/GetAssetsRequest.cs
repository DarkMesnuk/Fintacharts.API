namespace Fintacharts.API.Requests.Assets;

public class GetAssetsRequest
{
    public required List<Guid> AssetsIds { get; init; }
}