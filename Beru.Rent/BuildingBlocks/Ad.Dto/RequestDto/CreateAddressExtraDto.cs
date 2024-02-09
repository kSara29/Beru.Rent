namespace Ad.Dto.RequestDto;

public class CreateAddressExtraDto
{
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public required string Street { get; set; }
    public string? House { get; set; }
    public byte? Floor { get; set; }
    public string? Apartment { get; set; }
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string Region { get; set; }
    public string? PostIndex { get; set; }
}