

namespace Ad.Domain.Models;

public class AddressMain : Entity   
{
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string Region { get; set; }
    public string? PostIndex { get; set; }
}