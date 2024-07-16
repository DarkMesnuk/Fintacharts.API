using FintachartsAPI.Domain.Models.Assets;

namespace FintachartsAPI.Domain.Schemas.Assets;

public class UpdateAssetDataSchema
{
    public Guid Id { get; set; }
    public AssetPriceChangeModel? Ask { get; set; }
    public AssetPriceChangeModel? Bid { get; set; }
    public AssetPriceChangeModel? Last { get; set; }
}