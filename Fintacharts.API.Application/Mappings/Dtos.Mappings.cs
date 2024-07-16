using AutoMapper;
using Fintacharts.API.Application.Dtos.Assets;
using FintachartsAPI.Domain.Models.Assets;

namespace Fintacharts.API.Application.Mappings;

public class DtosMappings : Profile
{
    public DtosMappings()
    {
        CreateMap<AssetModel, AssetSimpleDto>();
        CreateMap<AssetModel, AssetDetailedDto>();
        CreateMap<AssetPriceChangeModel, AssetPriceChangeDto>();
    }
}