using Bff.Application.Contracts;
using Chat.Dto.RequestDto;
using Chat.Dto.ResponseModel;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.ChatService;

public class CreateChat(IChatService service): Endpoint<CreateChatRequest, ResponseModel<ChatDtoResponse>>
{
    public override void Configure()
    {
        Post("/bff/chat/createChat");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateChatRequest? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.CreateChatAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}