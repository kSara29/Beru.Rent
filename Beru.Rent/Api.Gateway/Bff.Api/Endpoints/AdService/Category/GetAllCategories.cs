using Ad.Application.DTO.GetDtos;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.Category;

public class GetAllCategories(ICategoryService service) : Endpoint<EmptyRequest, ResponseModel<List<CategoryDto?>>>
{
    public override void Configure()
    {
        Get("/bff/category/get");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        (EmptyRequest request,CancellationToken ct)
    {
        var response = await service.GetAllCategoriesAsync();
        await SendAsync(response, cancellation: ct);
    }
}
