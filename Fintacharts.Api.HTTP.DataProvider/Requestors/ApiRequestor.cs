using Fintacharts.Api.HTTP.DataProvider.Interfaces;
using Fintacharts.Api.HTTP.DataProvider.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Fintacharts.Api.HTTP.DataProvider.Requestors;

public class ApiRequestor(
    IHttpClientFactory httpClient,
    ILogger<ApiRequestor> logger
    ) : IApiRequestor
{
    public async Task<T> SendAsync<T>(ApiRequestModel apiRequest)
        where T : class, new()
    {
        try
        {
            var jsonResponse = await SendRequestAsync(apiRequest);
            var response = JsonConvert.DeserializeObject<T>(jsonResponse);

            if (response == null)
                throw new InvalidDataException();

            return response;
        }
        catch (Exception exception)
        {
            logger.LogWarning(exception, $"Error to send request to {apiRequest.Url}");

            return new T();
        }
    }

    private async Task<string> SendRequestAsync(ApiRequestModel apiRequest)
    {
        var message = new HttpRequestMessage
        {
            Method = apiRequest.Type,
            RequestUri = new Uri(apiRequest.Url),
        };
        
        message.Headers.Add("Accept", "application/json");

        if (apiRequest.Data != null)
        {
            if (apiRequest.Type == HttpMethod.Get)
            {
                message.RequestUri = new Uri(apiRequest.Url + GenerateQueryParams(apiRequest.Data));
            }
            else
            {
                if (apiRequest.ContentType == "application/x-www-form-urlencoded")
                {
                    var content = ToKeyValue(apiRequest.Data);
                    var formContent = new FormUrlEncodedContent(content);
                    message.Content = formContent;
                }
                else
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, apiRequest.ContentType);
                }
            }
        }
        
        var client = httpClient.CreateClient("Fintacharts");

        if (!string.IsNullOrEmpty(apiRequest?.AccessToken))
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);

        var apiResponse = await client.SendAsync(message);
        return await apiResponse.Content.ReadAsStringAsync();
    }
    
    private IDictionary<string, string> ToKeyValue(object? metaToken)
    {
        if (metaToken == null) 
            return new Dictionary<string, string>();

        var serializeSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        var token = metaToken as JToken;
        if (token == null)
        {
            try
            {
                var json = JsonConvert.SerializeObject(metaToken, serializeSettings);
                token = JToken.Parse(json);
            }
            catch (Exception)
            {
                return new Dictionary<string, string>();
            }
        }

        return token.Type == JTokenType.Object
            ? token.Children<JProperty>().ToDictionary(child => child.Name, child => child.Value.ToString())
            : new Dictionary<string, string> { { "", token.ToString() } };
    }

    private string GenerateQueryParams(object data)
    {
        var properties = data.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance);
        
        var keyValuePairs = new List<string>();

        foreach (var property in properties)
        {
            var value = property.GetValue(data);

            if (value != null)
                keyValuePairs.Add($"{property.Name}={value}");
        }

        return "?" + string.Join("&", keyValuePairs);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}