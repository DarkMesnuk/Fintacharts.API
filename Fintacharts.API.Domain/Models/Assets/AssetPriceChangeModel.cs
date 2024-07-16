using FintachartsAPI.Domain.Interfaces.Models;

namespace FintachartsAPI.Domain.Models.Assets;

public class AssetPriceChangeModel : IEntityModel
{
    public double Price { get; set; }
    public DateTime TimeStamp { get; set; }
}