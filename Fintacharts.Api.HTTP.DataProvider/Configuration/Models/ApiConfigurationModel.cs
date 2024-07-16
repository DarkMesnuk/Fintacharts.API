namespace Fintacharts.Api.HTTP.DataProvider.Configuration.Models;

public class ApiConfigurationModel
{
    public const string ConfigSectionName = "Api";
    public string Url { get; set; }
    public string AccessToken { get; set; }
}