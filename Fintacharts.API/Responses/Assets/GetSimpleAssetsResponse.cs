using Fintacharts.API.Application.Dtos.Assets;
using FintachartsAPI.Domain.Schemas.Base.Interfaces;

namespace Fintacharts.API.Responses.Assets;

public record GetSimpleAssetsResponse(IPaginatedResponseSchema<AssetSimpleDto> assets);