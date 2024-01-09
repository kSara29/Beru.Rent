namespace Ad.Application.DTO.CreateDtos;

public class CreateAddressExtraDto
{
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public required string Street { get; set; }
    public string? House { get; set; }
    public byte? Floor { get; set; }
    public string? Apartment { get; set; }
    public Guid AddressMainId { get; set; }
}