using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Domain.Models;

namespace Ad.Application.Mapper;

public static class CategoryMap
{
  public static Category ToDomain(this CreateCategoryDto dto)
  {
    return new Category
    {
      Title = dto.Title!,
      ParentId = dto.ParentId
    };
  }

  public static CategoryDto ToDto(this Category model)
  {
    return new CategoryDto
    {
      Id=model.Id,
      Title = model.Title,
      ParentId = model.ParentId,
      CreatedAt = model.CreatedAt
    };
  }
}