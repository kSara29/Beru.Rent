using Bff.Application.Contracts;
using Chat.Dto.ResponseModel;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.ChatService;

public class LoadChatHistory(IChatService service): Endpoint<RequestById, ResponseModel<List<MessageDto>>>
{
    public override void Configure()
    {
        Get("/bff/chat/loadChatHistoryById");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (RequestById? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.LoadChatHistoryAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}