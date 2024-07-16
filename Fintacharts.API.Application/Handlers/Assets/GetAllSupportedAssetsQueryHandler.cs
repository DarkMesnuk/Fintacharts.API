using AutoMapper;
using Fintacharts.API.Application.Dtos.Assets;
using Fintacharts.API.Application.Handlers.Base.Handlers;
using Fintacharts.API.Application.Handlers.Base.Requests;
using Fintacharts.API.Application.Handlers.Base.Responses;
using FintachartsAPI.Domain.Interfaces.Database;
using FintachartsAPI.Domain.Models.Assets;
using Microsoft.Extensions.Logging;

namespace Fintacharts.API.Application.Handlers.Assets;

public class GetAllSupportedAssetsQueryHandler(
    ILogger<GetAllSupportedAssetsQueryHandler> logger,
    IMapper mapper,
    IAssetsRepository assetRepository
    ) : BaseHandler<GetAllSupportedAssetsQueryRequest, GetAllSupportedAssetsQueryResponse>(logger)
{
    public override async Task<GetAllSupportedAssetsQueryResponse> Handle(GetAllSupportedAssetsQueryRequest request, CancellationToken cancellationToken)
    {
        var response = new GetAllSupportedAssetsQueryResponse(mapper);

        var assets = await assetRepository.GetSimplePaginatedAsync(request);
        
        return response.SetData(assets);
    }
}

public class GetAllSupportedAssetsQueryRequest : BasePaginatedHandlerRequest<GetAllSupportedAssetsQueryResponse>;

public class GetAllSupportedAssetsQueryResponse(
    IMapper mapper
    ) : BasePaginatedQueryResponse<GetAllSupportedAssetsQueryResponse, AssetSimpleDto, AssetModel>(mapper);