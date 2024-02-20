using Chat.Api.Hubs;
using Chat.Application.Contracts;
using Chat.Domain.Model;
using Chat.Dto.RequestDto;
using Chat.Dto.ResponseModel;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController: ControllerBase
{
    private readonly IChatService _chatService;
    private readonly IHubContext<ChatHub> _chatHub;
    private readonly ILogger<ChatController> _logger;

    public ChatController(IChatService chatService, 
        IHubContext<ChatHub> chatHub,
        ILogger<ChatController> logger)
    {
        _chatService = chatService;
        _chatHub = chatHub;
        _logger = logger;
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
    public async Task<Domain.Model.Chat?> SendMessage( SendMessageRequest request)
    {
        var chatParticipients = await _chatService.GetChatParticipants(request.ChatId);

        foreach (var userId in chatParticipients)
        {
            if (userId == request.UserId)
            {
                var newMessage = new Message()
                {
                    CreatedAt = DateTime.UtcNow,
                    MessageId = Guid.NewGuid(),
                    SenderId =  Guid.Parse(request.UserId),
                    Text = request.Message
                };
        
                var chatWithMessages = await _chatService.SaveMessageAsync(request.ChatId, newMessage);
        
                await _chatHub.Clients.All.SendAsync("ReceiveMessage", request.UserId, request.Message);
                
                _logger.LogInformation("Сообщение отправлено в чат {@chatId}", request.ChatId);
                return chatWithMessages;
            }
        }
        
        _logger.LogInformation("Пользователь не является участником чата");
        return null;
    }
    
    
    [HttpGet("/api/chat/history/{chatId}/{userId}")]
    public async Task<ResponseModel<List<MessageDto>>?> GetChatHistory(Guid chatId, string userId)
    {
        var chatParticipients = await _chatService.GetChatParticipants(chatId);
        foreach (var userChatParticipient in chatParticipients)
        {
            if (userChatParticipient == userId)
            {
                var messages = await _chatService.GetMessagesByChatIdAsync(chatId);
                return messages;
            }
        }
        return null;
    }

    [HttpGet("/api/chat/chats/{userId}")]
    public async Task<ResponseModel<List<GetAllChatsResponse>>> GetAllChatsByUserId(string userId)
    {
        var userChats = await _chatService.GetAllChats(userId);
        
        _logger.LogInformation("Возвращен список чатов пользователя");
        return userChats;
    }
}