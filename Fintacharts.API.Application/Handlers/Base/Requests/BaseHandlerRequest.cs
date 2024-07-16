using FintachartsAPI.Domain.Helpers.Models;
using MediatR;

namespace Fintacharts.API.Application.Handlers.Base.Requests;

public class BaseHandlerRequest<TResponse> : IRequest<TResponse> 
    where TResponse : ApplicationResponse;