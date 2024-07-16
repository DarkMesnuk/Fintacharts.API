namespace FintachartsAPI.Domain.Schemas.Base.Interfaces;

public interface IPaginatedResponseSchema<T>
{
    public int Count { get; set; }
    public int TotalCount { get; set; }
    public IEnumerable<T> Dtos { get; set; }
}