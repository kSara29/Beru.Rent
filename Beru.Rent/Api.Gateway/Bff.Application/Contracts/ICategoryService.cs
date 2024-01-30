using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface ICategoryService
{
    Task<ResponseModel<GuidResponse>> CreateCategoryAsync(CreateCategoryDto dto);
    Task<ResponseModel<CategoryDto?>> GetCategoryAsync(RequestById id);
    Task<ResponseModel<List<CategoryDto?>>> GetAllCategoriesAsync();
}