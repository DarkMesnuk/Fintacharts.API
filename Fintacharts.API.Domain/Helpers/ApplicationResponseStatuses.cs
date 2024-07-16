using FintachartsAPI.Domain.Helpers.Models;

namespace FintachartsAPI.Domain.Helpers;

public enum StatusCodes
{
    Success = 1000,
    NotFound = 1001,
    SomethingWentWrong = 1002,
    CreationFailed = 1003,
    UpdateFailed = 1004,
    DeleteFailed = 1005,
}

public static class ApplicationResponseStatuses
{
    public static readonly Dictionary<StatusCodes, ApplicationResponse> Statuses;

    static ApplicationResponseStatuses()
    {
        Statuses = new Dictionary<StatusCodes, ApplicationResponse>();

        Statuses.CreatePair(StatusCodes.Success, "Success", 200)
            .CreatePair(StatusCodes.NotFound, "Not found", 404)
            .CreatePair(StatusCodes.SomethingWentWrong, "Something went wrong", 400);
    }
    
    private static Dictionary<StatusCodes, ApplicationResponse> CreatePair(this Dictionary<StatusCodes, ApplicationResponse> statuses, StatusCodes statusCode, string description, int httpCode)
    {
        statuses.Add(statusCode, new ApplicationResponse { Status = statusCode.GetStatusCode(), Type = statusCode.ToString(), Description = description, HttpCode = httpCode} );
        return statuses;
    }

    private static string GetStatusCode(this StatusCodes code)
    {
        return $"{(int)code}";
    }
}