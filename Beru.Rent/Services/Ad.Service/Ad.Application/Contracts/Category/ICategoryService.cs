using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Responses;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Contracts.Category;

public interface ICategoryService
{
    Task<ResponseModel<GuidResponse>> CreateAsync(CreateCategoryDto dto);
    Task<ResponseModel<CategoryDto?>> GetAsync(Guid id);
    Task<ResponseModel<List<CategoryDto?>>> GetAllAsync();


}