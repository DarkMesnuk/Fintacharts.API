using Fintacharts.API.Application.Dtos.Interfaces;

namespace Fintacharts.API.Application.Dtos.Assets;

public class AssetDetailedDto : IEntityDto
{
    public Guid Id { get; set; }
    public string Symbol { get; set; }
    public string Kind { get; set; }
    public string Exchange { get; set; }
    public string Description { get; set; }
    public decimal TickSize { get; set; }
    public string Currency { get; set; }
    
    public AssetPriceChangeDto Ask { get; set; }
    public AssetPriceChangeDto Bid { get; set; }
    public AssetPriceChangeDto Last { get; set; }
}