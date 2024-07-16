using FintachartsAPI.Domain.Schemas.Base.Interfaces;

namespace Fintacharts.API.Requests.Base;

public abstract class BasePaginatedRequest : IPaginatedSchema
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}