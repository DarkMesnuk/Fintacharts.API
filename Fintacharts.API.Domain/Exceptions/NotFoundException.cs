using FintachartsAPI.Domain.Helpers;
using System.Net;

namespace FintachartsAPI.Domain.Exceptions;

[HttpStatusCode(HttpStatusCode.BadRequest)]
public class NotFoundException : FintachartsException
{
    public NotFoundException(string entityType, int id)
        : base(StatusCodes.NotFound, $"{entityType} {id} is not found")
    {
    }
    
    public NotFoundException(string entityType, string name)
        : base(StatusCodes.NotFound, $"{entityType} {name} is not found")
    {
    }
    
    public NotFoundException(string entityType)
        : base(StatusCodes.NotFound, $"{entityType} by filter is not found")
    {
    }
}