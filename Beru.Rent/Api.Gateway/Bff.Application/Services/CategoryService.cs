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
    ServiceHandler<GuidResponse> serviceHandlerGuid,
    ServiceHandler<List<CategoryDto?>> serviceHandlerListCategories,
    ServiceHandler<CategoryDto?> serviceHandlerCategoryDto,
    IOptions<RequestToAdApi> jsonOptions):ICategoryService
{
    public async Task<ResponseModel<GuidResponse>> CreateCategoryAsync(CreateCategoryDto dto)
    {
        var jsonContent = JsonConvert.SerializeObject(dto);
        var url = serviceHandlerGuid.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/category/post");
        return await serviceHandlerGuid.PostConnectionHandler(url, jsonContent);
    }

    public async Task<ResponseModel<CategoryDto?>> GetCategoryAsync(RequestById id)
    {
        var url = serviceHandlerCategoryDto.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/category/get/", id.Id.ToString());
        var result = await serviceHandlerCategoryDto.GetConnectionHandler(url);
        return result;
    }

    public async Task<ResponseModel<List<CategoryDto?>>> GetAllCategoriesAsync()
    {
        var url = serviceHandlerListCategories.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/category/get", null);
        var result = await serviceHandlerListCategories.GetConnectionHandler(url);
        return result;
    }
}