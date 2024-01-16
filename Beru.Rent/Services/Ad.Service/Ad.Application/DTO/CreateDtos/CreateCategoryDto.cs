namespace Ad.Application.DTO.CreateDtos;

public class CreateCategoryDto
{
    public string? Title { get; set; }
    public Guid? ParentId { get; set; }
}