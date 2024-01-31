using Chat.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController: ControllerBase
{
    private readonly IChatService _charService;

    public ChatController(IChatService charService)
    {
        _charService = charService;
    }
    
    [HttpGet("/api/chat/create/{user1}/{user2}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<Domain.Model.Chat> CreateChatAsync([FromRoute] Guid user1, Guid user2)
    {
        var newChat = await _charService.CreateChatAsync(user1, user2);
        return newChat;
    }
}