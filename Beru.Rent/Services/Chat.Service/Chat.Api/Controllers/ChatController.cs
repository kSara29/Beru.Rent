using Chat.Api.Dto;
using Chat.Api.Hubs;
using Chat.Application.Contracts;
using Chat.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController: ControllerBase
{
    private readonly IChatService _chatService;
    private readonly IHubContext<ChatHub> _chatHub;

    public ChatController(IChatService chatService, IHubContext<ChatHub> chatHub)
    {
        _chatService = chatService;
        _chatHub = chatHub;
    }
    
    [HttpGet("/api/chat/create/{user1}/{user2}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<Domain.Model.Chat> CreateChatAsync([FromRoute] Guid user1, Guid user2)
    {
        var newChat = await _chatService.CreateChatAsync(user1, user2);
        return newChat;
    }
    
    [HttpPost("/api/chat/send")]
    public async Task<Domain.Model.Chat> SendMessage([FromBody] SendMessageRequest request)
    {
        var newMessage = new Message()
        {
            CreatedAt = DateTime.UtcNow,
            MessageId = Guid.NewGuid(),
            SenderId = Guid.NewGuid(),
            Text = request.Message
        };
        
        var chatWithMessages = await _chatService.SaveMessageAsync(request.ChatId, newMessage);
        
        await _chatHub.Clients.All.SendAsync("ReceiveMessage", request.Message);

        return chatWithMessages;
    }
    
    
    [HttpGet("/api/chat/history/{chatId}")]
    public async Task<IActionResult> GetChatHistory(Guid chatId)
    {
        var messages = await _chatService.GetMessagesByChatIdAsync(chatId);
        return Ok(messages);
    }
}