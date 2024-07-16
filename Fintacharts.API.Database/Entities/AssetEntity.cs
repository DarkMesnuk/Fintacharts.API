using Fintacharts.API.Database.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fintacharts.API.Database.Entities;

public class AssetEntity : IEntity<Guid>
{
    [Key]
    public Guid Id { get; set; }
    public string Symbol { get; set; }
    public string? Kind { get; set; }
    public string? Exchange { get; set; }
    public string? Description { get; set; }
    public decimal TickSize { get; set; }
    public string Currency { get; set; }
    
    public double AskPrice { get; set; }
    public DateTime AskTimeStamp { get; set; }
    public double BidPrice { get; set; }
    public DateTime BidTimeStamp { get; set; }
    public double LastPrice { get; set; }
    public DateTime LastTimeStamp { get; set; }
}