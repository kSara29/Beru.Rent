using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Responses;

namespace Ad.Application.Contracts.Category;

public interface ICategoryService
{
    Task<BaseApiResponse<Guid>> CreateAsync(CreateCategoryDto dto);
    Task<BaseApiResponse<CategoryDto?>> GetAsync(Guid id);
    Task<BaseApiResponse<List<CategoryDto?>>> GetAllAsync();


}