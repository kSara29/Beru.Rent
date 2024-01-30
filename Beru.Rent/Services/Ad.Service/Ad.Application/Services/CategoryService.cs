using Ad.Application.Contracts.Category;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Mapper;
using Ad.Application.Responses;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Services;

public class CategoryService:ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseModel<GuidResponse>> CreateAsync(CreateCategoryDto dto)
    {
        var result = await _repository.CreateAsync(dto.ToDomain());
        return ResponseModel<GuidResponse>.CreateSuccess(new GuidResponse
        {
            Id = result
        });
    }

    public async Task<ResponseModel<CategoryDto?>> GetAsync(Guid id)
    {
        var result = await _repository.GetAsync(id);
        if (result != null)
        {
            return ResponseModel<CategoryDto?>.CreateSuccess(result.ToDto());
        }
        var errors = new List<ResponseError>();
        var errorModel = new ResponseError
        {
            Code = "404",
            Message = "С таким Id категории не найдено"
        };
        errors.Add(errorModel);
        return ResponseModel<CategoryDto?>.CreateFailed(errors);  
    }

    public async Task<ResponseModel<List<CategoryDto?>>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        return ResponseModel<List<CategoryDto?>>.CreateSuccess(result.Select(c => c.ToDto()).ToList());

    }
}