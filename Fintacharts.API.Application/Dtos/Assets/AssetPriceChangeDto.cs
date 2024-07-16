using Fintacharts.API.Application.Dtos.Interfaces;

namespace Fintacharts.API.Application.Dtos.Assets;

public class AssetPriceChangeDto : IEntityDto
{
    public double Price { get; set; }
    public DateTime TimeStamp { get; set; }
}