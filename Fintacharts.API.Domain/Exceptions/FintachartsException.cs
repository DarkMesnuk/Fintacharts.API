using FintachartsAPI.Domain.Helpers;
using FintachartsAPI.Domain.Helpers.Models;

namespace FintachartsAPI.Domain.Exceptions;

public abstract class FintachartsException : Exception
{
    protected FintachartsException() : this(StatusCodes.SomethingWentWrong)
    {
    }
    
    protected FintachartsException(string error) : this(StatusCodes.SomethingWentWrong, error)
    {
    }
    
    protected FintachartsException(StatusCodes code, string error) : this(code)
    {
        ErrorResponse.SetAdditionalMessage(error);
    }
    
    protected FintachartsException(StatusCodes code)
    {
        var result = ApplicationResponseStatuses.Statuses.GetValueOrDefault(code);
        ErrorResponse = new ApplicationResponse().SetData(result);
    }

    public ApplicationResponse ErrorResponse { get; }
}