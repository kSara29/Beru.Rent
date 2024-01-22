using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints;

public class GetUserByMail(IHttpClientFactory httpClientFactory) : Endpoint<object, object>
{
    public override void Configure()
    {
        Get("/api/user/getByMail");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (object? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var client = httpClientFactory.CreateClient();
        var result = await client.GetAsync($"https://localhost:7258/api/user/getByMail?Email={request}");
        
        await SendAsync(result, cancellation: ct);
    }
}