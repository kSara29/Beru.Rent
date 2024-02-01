

using Ad.Application.DTO.CreateDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

public class CreateCategory(ICategoryService service) : Endpoint<CreateCategoryDto, ResponseModel<GuidResponse>>
{
    public override void Configure()
    {
        Post("/bff/category/create");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateCategoryDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.CreateCategoryAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}