

using Ad.Domain.Models.Common;

namespace Ad.Domain.Models;

public class AddressExtra : Entity
{
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public required string Street { get; set; }
    public string? House { get; set; }
    public byte? Floor { get; set; }
    public string? Apartment { get; set; }
    public Guid AddressMainId { get; set; }
    public AddressMain? AddressMain { get; set; }
}