using Fintacharts.Api.HTTP.DataProvider.Models;

namespace Fintacharts.Api.HTTP.DataProvider.Responses.Base;

public class PaginatedResponse<T>
{
    public PageInfoModel Paging { get; set; }
    public List<T> Data { get; set; }   
}