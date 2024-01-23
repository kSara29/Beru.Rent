using Ad.Application.Contracts.Category;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Mapper;
using Ad.Application.Responses;

namespace Ad.Application.Services;

public class CategoryService:ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseApiResponse<Guid>> CreateAsync(CreateCategoryDto dto)
    {
        var result = await _repository.CreateAsync(dto.ToDomain());
        return new BaseApiResponse<Guid>(result);
    }

    public async Task<BaseApiResponse<CategoryDto?>> GetAsync(Guid id)
    {
        var result = await _repository.GetAsync(id);
        return new BaseApiResponse<CategoryDto?>(result.ToDto());
    }

    public async Task<BaseApiResponse<List<CategoryDto?>>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        return new BaseApiResponse<List<CategoryDto?>>(result.Select(c => c.ToDto()).ToList());

    }
}