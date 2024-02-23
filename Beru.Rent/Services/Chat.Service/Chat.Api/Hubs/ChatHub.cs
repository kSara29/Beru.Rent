using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Hubs;

public class ChatHub : Hub
{
    private readonly Dictionary<string, List<string>> _chatConnections = new();

    public async Task SendMessage(string chatId, string user, string message)
    {
        if (_chatConnections.ContainsKey(chatId))
        {
            var connectionIds = _chatConnections[chatId];
            await Clients.Clients(connectionIds).SendAsync("ReceiveMessage", user, message);
        }
    }

    public override async Task OnConnectedAsync()
    {
        string chatId = Context.GetHttpContext().Request.Query["chatId"];

        if (!string.IsNullOrEmpty(chatId))
        {
            if (!_chatConnections.ContainsKey(chatId))
            {
                _chatConnections[chatId] = new List<string>();
            }

            _chatConnections[chatId].Add(Context.ConnectionId);
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        foreach (var chatConnections in _chatConnections.Values)
        {
            chatConnections.Remove(Context.ConnectionId);
        }

        await base.OnDisconnectedAsync(exception);
    }
}