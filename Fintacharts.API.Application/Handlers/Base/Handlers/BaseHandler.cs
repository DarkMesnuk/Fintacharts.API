using MediatR;
using Microsoft.Extensions.Logging;

namespace Fintacharts.API.Application.Handlers.Base.Handlers;

public abstract class BaseHandler<TRequest, TResponse>(
    ILogger<BaseHandler<TRequest, TResponse>> logger
    ) : IRequestHandler<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : class
{
    protected readonly ILogger<BaseHandler<TRequest, TResponse>> Logger = logger;
    
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}