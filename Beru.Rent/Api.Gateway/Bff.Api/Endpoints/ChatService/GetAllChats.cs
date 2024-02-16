using System.Security.Claims;
using Bff.Application.Contracts;
using Chat.Dto.RequestDto;
using Chat.Dto.ResponseModel;
using Common;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Bff.Api.Endpoints.ChatService;

public class GetAllChats(IChatService service): Endpoint<GetChatsByIdRequest, ResponseModel<List<GetAllChatsResponse>>>
{
    public override void Configure()
    {
        Get("/bff/chat/chats");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (GetChatsByIdRequest? request, CancellationToken ct)
    { 
        //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetAllChatsByUserId(request!);
        await SendAsync(response, cancellation: ct);
    }
}