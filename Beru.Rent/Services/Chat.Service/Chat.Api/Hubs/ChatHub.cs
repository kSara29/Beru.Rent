﻿using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.Others.SendAsync("ReceiveMessage", user, message);
    }
}