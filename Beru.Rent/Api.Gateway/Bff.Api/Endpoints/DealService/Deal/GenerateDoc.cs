using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService.Deal;

public class GenerateDoc(IDocumentService _service) : Endpoint<RequestById, ResponseModel<DocDataDto>>
{
    public override void Configure()
    {
        Get("/bff/deal/generateDoc/");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (RequestById? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await _service.GenerateDoc(request!);
        await SendAsync(response, cancellation: ct);
    }
}