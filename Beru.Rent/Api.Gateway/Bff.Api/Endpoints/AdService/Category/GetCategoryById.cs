using Ad.Application.DTO.GetDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.Category;

public class GetCategoryById(ICategoryService service) : Endpoint<RequestById, ResponseModel<CategoryDto?>>
{
    public override void Configure()
    {
        Get("/bff/category/getById");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        (RequestById request,CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetCategoryAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}