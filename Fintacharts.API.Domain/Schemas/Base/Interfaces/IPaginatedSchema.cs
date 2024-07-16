namespace FintachartsAPI.Domain.Schemas.Base.Interfaces;

public interface IPaginatedSchema
{
    int PageNumber { get; init; }
    int PageSize { get; init; }
}