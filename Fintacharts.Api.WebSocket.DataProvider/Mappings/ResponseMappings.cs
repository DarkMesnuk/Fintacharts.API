using AutoMapper;
using Fintacharts.Api.WebSocket.DataProvider.Responses;
using FintachartsAPI.Domain.Schemas.Assets;

namespace Fintacharts.Api.WebSocket.DataProvider.Mappings;

public class ResponseMappings : Profile
{
    public ResponseMappings()
    {
        CreateMap<GetAssetsDataStreamResponse, UpdateAssetDataSchema>();
    }
}