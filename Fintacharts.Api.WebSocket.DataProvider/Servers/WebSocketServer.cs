using Fintacharts.Api.WebSocket.DataProvider.Interfaces.Servers;
using Fintacharts.Api.WebSocket.DataProvider.Models;
using Websocket.Client;

namespace Fintacharts.Api.WebSocket.DataProvider.Servers;

public class WebSocketServer : IWebSocketServer
{
    private WebsocketClient client;

    public void Configure(ConnectRequestModel request)
    {
        client = new WebsocketClient(new Uri($"{request.Url}?token={request.AccessToken}"));
    }
    
    public void Subscribe(Action<ResponseMessage> action)
    {
        client.MessageReceived.Subscribe(action);
    }

    public Task StartAsync()
    {
        return client.StartOrFail();
    }

    public bool SendRequest(string request)
    {
        return client.Send(request);   
    }
    
    public void Dispose()
    {
        client.Dispose();
    }
}