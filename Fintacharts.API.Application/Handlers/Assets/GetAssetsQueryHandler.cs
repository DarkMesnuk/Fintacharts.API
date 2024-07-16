using AutoMapper;
using Fintacharts.API.Application.Dtos.Assets;
using Fintacharts.API.Application.Handlers.Base.Handlers;
using Fintacharts.API.Application.Handlers.Base.Requests;
using Fintacharts.API.Application.Handlers.Base.Responses;
using FintachartsAPI.Domain.Interfaces.Database;
using FintachartsAPI.Domain.Models.Assets;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Fintacharts.API.Application.Handlers.Assets;

public class GetAssetsQueryHandler(
    ILogger<GetAssetsQueryHandler> logger,
    IMapper mapper,
    IAssetsRepository assetRepository
    ) : BaseHandler<GetAssetsQueryRequest, GetAssetsQueryResponse>(logger)
{
    public override async Task<GetAssetsQueryResponse> Handle(GetAssetsQueryRequest request, CancellationToken cancellationToken)
    {
        var response = new GetAssetsQueryResponse(mapper);
        
        var assets = await assetRepository.GetDetailedAsync(request.AssetsIds);
        
        return response.SetData(assets);
    }
}

public class GetAssetsQueryRequest : BaseHandlerRequest<GetAssetsQueryResponse>
{
    public required List<Guid> AssetsIds { get; init; }
}

public class GetAssetsQueryResponse(
    IMapper mapper
    ) : BaseListQueryResponse<GetAssetsQueryResponse, AssetDetailedDto, AssetModel>(mapper);

public class GetAssetsRequestValidator : AbstractValidator<GetAssetsQueryRequest>
{
    public GetAssetsRequestValidator()
    {
        RuleFor(x => x.AssetsIds)
            .NotEmpty()
            .NotNull();
    }
}