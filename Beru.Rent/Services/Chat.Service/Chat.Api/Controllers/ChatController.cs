using Chat.Api.Hubs;
using Chat.Application.Contracts;
using Chat.Domain.Model;
using Chat.Dto.RequestDto;
using Chat.Dto.ResponseModel;
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
    
    [HttpPost("/api/chat/create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<ChatDtoResponse> CreateChatAsync([FromBody] CreateChatRequest newChat)
    {
        var chat = await _chatService.CreateChatAsync(newChat);
        ChatDtoResponse model = new ChatDtoResponse()
        {
            Id = chat.Id,
            Participants = chat.Participants,
            CreatedAt = chat.CreatedAt
        };
        
        return model;
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
        return Ok();
    }
}