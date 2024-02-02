using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Bff.Application.Services;

public class CategoryService(
    ServiceHandler serviceHandler,
    IOptions<RequestToAdApi> jsonOptions):ICategoryService
{
    public async Task<ResponseModel<GuidResponse>> CreateCategoryAsync(CreateCategoryDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/category/post");
        return await serviceHandler.PostConnectionHandler<CreateCategoryDto, GuidResponse>(url, dto);
    }

    public async Task<ResponseModel<CategoryDto?>> GetCategoryAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/category/get/", id.Id.ToString());
        var result = await serviceHandler.GetConnectionHandler<CategoryDto>(url);
        return result;
    }

    public async Task<ResponseModel<List<CategoryDto?>>> GetAllCategoriesAsync()
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/category/get", null);
        var result = await serviceHandler.GetConnectionHandler<List<CategoryDto>>(url);
        return result;
    }
}