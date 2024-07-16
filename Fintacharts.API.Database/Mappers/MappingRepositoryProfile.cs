using AutoMapper;
using Fintacharts.API.Database.Entities;
using FintachartsAPI.Domain.Models.Assets;

namespace Fintacharts.API.Database.Mappers;

public class MappingRepositoryProfile : Profile
{
    public MappingRepositoryProfile()
    {
        CreateMap<AssetModel, AssetEntity>()
            .ForMember(x => x.AskPrice, expression => expression.MapFrom(x => x.Ask != null ? x.Ask.Price : default))
            .ForMember(x => x.AskTimeStamp, expression => expression.MapFrom(x => x.Ask != null ? x.Ask.TimeStamp : default))
            .ForMember(x => x.BidPrice, expression => expression.MapFrom(x => x.Bid != null ? x.Bid.Price : default))
            .ForMember(x => x.BidTimeStamp, expression => expression.MapFrom(x => x.Bid != null ? x.Bid.TimeStamp : default))
            .ForMember(x => x.LastPrice, expression => expression.MapFrom(x => x.Last != null ? x.Last.Price : default))
            .ForMember(x => x.LastTimeStamp, expression => expression.MapFrom(x => x.Last != null ? x.Last.TimeStamp : default));

        CreateMap<AssetEntity, AssetModel>()
            .ForMember(x => x.Ask, expression => expression.MapFrom(x => new AssetPriceChangeModel
            {
                Price = x.AskPrice,
                TimeStamp = x.AskTimeStamp
            }))
            .ForMember(x => x.Bid, expression => expression.MapFrom(x => new AssetPriceChangeModel
            {
                Price = x.BidPrice,
                TimeStamp = x.BidTimeStamp
            }))
            .ForMember(x => x.Last, expression => expression.MapFrom(x => new AssetPriceChangeModel
            {
                Price = x.LastPrice,
                TimeStamp = x.LastTimeStamp
            }));
    }
}