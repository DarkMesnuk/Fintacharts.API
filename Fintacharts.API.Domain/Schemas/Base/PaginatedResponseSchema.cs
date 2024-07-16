using FintachartsAPI.Domain.Schemas.Base.Interfaces;

namespace FintachartsAPI.Domain.Schemas.Base;

public class PaginatedResponseSchema<T> : IPaginatedResponseSchema<T>
{
    public int Count { get; set; }
    public int TotalCount { get; set; }
    public IEnumerable<T> Dtos { get; set; }
}