using Fintacharts.Api.WebSocket.DataProvider.Models;
using Websocket.Client;

namespace Fintacharts.Api.WebSocket.DataProvider.Interfaces.Servers;

public interface IWebSocketServer : IDisposable
{
    void Configure(ConnectRequestModel request);
    void Subscribe(Action<ResponseMessage> action);
    Task StartAsync();
    bool SendRequest(string request);
}