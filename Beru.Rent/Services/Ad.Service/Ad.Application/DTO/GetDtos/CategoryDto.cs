namespace Ad.Application.DTO.GetDtos;

public class CategoryDto
{
    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? Title { get; set; }
    public Guid? ParentId { get; set; }
}