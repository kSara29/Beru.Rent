namespace Ad.Application.DTO.GetDtos;

public class AddressMainDto
{
    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostIndex { get; set; }
}