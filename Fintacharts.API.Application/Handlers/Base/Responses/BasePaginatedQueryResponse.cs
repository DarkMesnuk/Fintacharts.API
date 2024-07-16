using AutoMapper;
using Fintacharts.API.Application.Dtos.Interfaces;
using FintachartsAPI.Domain.Helpers;
using FintachartsAPI.Domain.Helpers.Models;
using FintachartsAPI.Domain.Interfaces.Models;
using FintachartsAPI.Domain.Schemas.Base.Interfaces;

namespace Fintacharts.API.Application.Handlers.Base.Responses;

public abstract class BasePaginatedQueryResponse<T, TDto, TModel>(
    IMapper mapper
    ) : BaseListQueryResponse<T, TDto, TModel>(mapper), IPaginatedResponseSchema<TDto>
    where T : ApplicationResponse
    where TDto : IEntityDto, new()
    where TModel : IEntityModel, new()
{

    public int Count { get; set; }
    public int TotalCount { get; set; }

    public T SetData(IPaginatedResponseSchema<TModel> schema)
    {
        SetData(StatusCodes.Success);

        Count = schema.Count;
        TotalCount = schema.TotalCount;
        Dtos = Mapper.Map<IEnumerable<TDto>>(schema.Dtos);

        return (this as T)!;
    }
}