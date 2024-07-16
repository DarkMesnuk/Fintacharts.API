using FintachartsAPI.Domain.Helpers.Models;
using FintachartsAPI.Domain.Schemas.Base.Interfaces;

namespace Fintacharts.API.Application.Handlers.Base.Requests;

public abstract class BasePaginatedHandlerRequest<TResponse> : BaseHandlerRequest<TResponse>, IPaginatedSchema
    where TResponse : ApplicationResponse
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}