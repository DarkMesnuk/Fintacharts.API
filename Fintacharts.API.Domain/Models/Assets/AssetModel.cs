using FintachartsAPI.Domain.Interfaces.Models;

namespace FintachartsAPI.Domain.Models.Assets;

public class AssetModel : IEntityModel<Guid>
{
    public Guid Id { get; set; }
    public string Symbol { get; set; }
    public string Kind { get; set; }
    public string Exchange { get; set; }
    public string Description { get; set; }
    public decimal TickSize { get; set; }
    public string Currency { get; set; }
    
    public AssetPriceChangeModel? Ask { get; set; }
    public AssetPriceChangeModel? Bid { get; set; }
    public AssetPriceChangeModel? Last { get; set; }
}