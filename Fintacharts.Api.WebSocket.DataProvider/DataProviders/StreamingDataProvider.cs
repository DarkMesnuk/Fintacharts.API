using AutoMapper;
using Fintacharts.Api.WebSocket.DataProvider.Configuration.Endpoints;
using Fintacharts.Api.WebSocket.DataProvider.Configuration.Models;
using Fintacharts.Api.WebSocket.DataProvider.Interfaces.Servers;
using Fintacharts.Api.WebSocket.DataProvider.Models;
using Fintacharts.Api.WebSocket.DataProvider.Payloads;
using Fintacharts.Api.WebSocket.DataProvider.Responses;
using FintachartsAPI.Domain.Interfaces.DataProvider;
using FintachartsAPI.Domain.Schemas.Assets;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Fintacharts.Api.WebSocket.DataProvider.DataProviders;

public class StreamingDataProvider(
    IWebSocketServer webSocketServer,
    ILogger<StreamingDataProvider> logger,
    IMapper mapper,
    IOptions<WebSocketConfigurationModel> configurationModel,
    IOptions<StreamingEndpointModel> streamingEndpointModel
    ) : IStreamingDataProvider
{
    
    public async Task<bool> StartConnectionAsync(Action<UpdateAssetDataSchema> eventHandler)
    {
        var url = $"{configurationModel.Value.Url}/{streamingEndpointModel.Value.InstrumentData}";
        
        var connectRequest = new ConnectRequestModel
        {
            Url = url,
            AccessToken = configurationModel.Value.AccessToken,
        };
        
        webSocketServer.Configure(connectRequest);
        webSocketServer.Subscribe(x => eventHandler(mapper.Map<UpdateAssetDataSchema>(JsonConvert.DeserializeObject<GetAssetsDataStreamResponse>(x.Text))));
        
        try
        {
            await webSocketServer.StartAsync();
        }
        catch (Websocket.Client.Exceptions.WebsocketException ex)
        {
            logger.LogError("[StreamingDataProvider] has problem with WebSocketServer: {Message}, inner exception: {InnerExceptionMessage}, stack trace: {StackTrace}", ex.Message, ex.InnerException?.Message, ex.StackTrace);
            return false;
        }
        catch (Exception ex)
        {
            logger.LogWarning("[StreamingDataProvider] assign exception: {Message}, inner exception: {InnerExceptionMessage}, stack trace: {StackTrace}", ex.Message, ex.InnerException?.Message, ex.StackTrace);
            return false;
        }
        
        return true;
    }
    
    public async Task SubscribeToGetAssetsDataAsync(Guid assetId, int requestId)
    {
        var request = new SubscribeToGetAssetDataPayload
        {
            Type = "l1-subscription",
            Id = requestId.ToString(),
            AssetId = assetId.ToString(),
            Provider = "simulation",
            Subscribe = true,
            Kinds =
            [
                "ask",
                "bid",
                "last"
            ]
        };

        var jsonRequest = JsonConvert.SerializeObject(request); 

        webSocketServer.SendRequest(jsonRequest);
    }
    
    public void Dispose()
    {
        webSocketServer.Dispose();
    }
}