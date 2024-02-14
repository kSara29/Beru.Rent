using System.Security.Claims;
using Bff.Application.Contracts;
using Chat.Dto.ResponseModel;
using Common;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Bff.Api.Endpoints.ChatService;

public class LoadChatHistory(IChatService service): Endpoint<RequestById, ResponseModel<List<MessageDto>>>
{
    public override void Configure()
    {
        Get("/bff/chat/loadChatHistoryById");
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }
    
    public override async Task HandleAsync
        (RequestById? request, CancellationToken ct)
    { 
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.LoadChatHistoryAsync(request!, userId);
        await SendAsync(response, cancellation: ct);
    }
}