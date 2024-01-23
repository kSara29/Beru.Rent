

using Ad.Domain.Models.Common;

namespace Ad.Domain.Models;

public class AddressExtra : Entity
{
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostIndex { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public required string Street { get; set; }
    public string? House { get; set; }
    public byte? Floor { get; set; }
    public string? Apartment { get; set; }
    
}