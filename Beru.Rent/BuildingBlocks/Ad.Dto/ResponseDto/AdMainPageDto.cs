using Ad.Domain.Models;

namespace Ad.Application.DTO.GetDtos;

public class AdMainPageDto
{
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public Guid? UserId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public AdState? State { get; set; }
    public decimal? Price { get; set; }
    public string Category { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? TimeUnitId { get; set; }
    public string? TimeUnit { get; set; }
    public string? City { get; set; }
    public string Street { get; set; }
    public List<byte[]>? Files { get; set; }
}