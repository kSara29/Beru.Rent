namespace Ad.Application.DTO.GetDtos;

public class TimeUnitDto
{
    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? Title { get; set; }
    public TimeSpan? Duration { get; set; }
}