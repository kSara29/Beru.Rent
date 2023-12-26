using Ad.Domain.Core.Models.Common;

namespace Ad.Domain.Core.Models;

public class AddressMain : Entity   
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostIndex { get; set; }
}