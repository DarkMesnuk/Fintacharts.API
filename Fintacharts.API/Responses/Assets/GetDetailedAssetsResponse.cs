using Fintacharts.API.Application.Dtos.Assets;

namespace Fintacharts.API.Responses.Assets;

public record GetDetailedAssetsResponse(IEnumerable<AssetDetailedDto> assets);