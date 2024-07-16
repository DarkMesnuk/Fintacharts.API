using Fintacharts.Api.HTTP.DataProvider.Models;

namespace Fintacharts.Api.HTTP.DataProvider.Interfaces;

public interface IApiRequestor : IDisposable
{
    Task<T> SendAsync<T>(ApiRequestModel apiRequest)
        where T : class, new();
}