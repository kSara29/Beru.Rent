using Bff.Application.Contracts;
using Chat.Dto.RequestDto;
using Chat.Dto.ResponseModel;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.ChatService;

public class SendMessage(IChatService service): Endpoint<SendMessageRequest, ResponseModel<SendMessageResponse>>
{
    public override void Configure()
    {
        Post("/bff/chat/sendMessageByChatId");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (SendMessageRequest? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.SendMessageAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}