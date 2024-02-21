using System.Security.Claims;
using Bff.Application.Contracts;
using Chat.Dto.RequestDto;
using Chat.Dto.ResponseModel;
using Common;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Bff.Api.Endpoints.ChatService;

public class SendMessage(IChatService service, ILogger<SendMessage> logger): Endpoint<SendMessageRequest, ResponseModel<SendMessageResponse>>
{
    public override void Configure()
    {
        Post("/bff/chat/sendMessageByChatId");
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme); 
    }
    
    public override async Task HandleAsync
        (SendMessageRequest? request, CancellationToken ct)
    { 
        request.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.SendMessageAsync(request!);
        
        logger.LogInformation("callback от chatService {@response}", response);
        await SendAsync(response, cancellation: ct);
    }
}