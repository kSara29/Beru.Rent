namespace Ad.Application.DTO.GetDtos;

public class AddressExtraDto
{
    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public required string Street { get; set; }
    public string? House { get; set; }
    public byte? Floor { get; set; }
    public string? Apartment { get; set; }
    public Guid AddressMainId { get; set; }
}