namespace Ad.Application.DTO.CreateDtos;

public class CreateAddressMainDto
{
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string Region { get; set; }
    public string? PostIndex { get; set; }
}